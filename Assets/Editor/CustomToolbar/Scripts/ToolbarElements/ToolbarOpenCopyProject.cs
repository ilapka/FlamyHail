using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;

[Serializable]
internal class ToolbarCopyProject : BaseToolbarElement 
{
	private static GUIContent copyProjectBtn;

	public override string NameInList => "[Button] Open copy project";

	public override void Init() 
	{
		copyProjectBtn = new GUIContent((Texture2D)AssetDatabase.LoadAssetAtPath($"{GetPackageRootPath}/Editor/CustomToolbar/Icons/new_window.png", typeof(Texture2D)), "Open copy project");
	}

	protected override void OnDrawInList(Rect position) 
	{

	}

	protected override void OnDrawInToolbar() 
	{
		if (GUILayout.Button(copyProjectBtn, UnityToolbarExtender.ToolbarStyles.commandButtonStyle))
		{
			OpenLinkProject();
		}
	}
	
	private static void OpenLinkProject()
	{
		DirectoryInfo unityExe = new DirectoryInfo(EditorApplication.applicationPath);
		DirectoryInfo projectPath = new DirectoryInfo(GetProjectPath());
		
		string[] directories = new[]
		{
			"Assets",
			"Library",
			"ProjectSettings",
			"Packages"
		};

		string instanceName = $"{projectPath.Name}_link";
		string linksFolder = ".links";
		string linkPath = Path.Combine(projectPath.FullName, linksFolder);
		string instancePath = Path.Combine(linkPath, instanceName);

		// create .links dirrectory
		DirectoryInfo linkPathInfo;
		if (!Directory.Exists(linkPath))
		{
			Debug.Log("Create links directory " + linkPath);
			linkPathInfo = Directory.CreateDirectory(linkPath);
		}
		else
		{
			linkPathInfo = new DirectoryInfo(linkPath);
		}

		linkPathInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.NotContentIndexed;

		// exclude from indexing in rider
		string ideaDirName = ".idea";
		string ideaIndexLayoutPath = Path.Combine(projectPath.FullName, ideaDirName, $"{ideaDirName}.{projectPath.Name}", ideaDirName, "indexLayout.xml");
		if(File.Exists(ideaIndexLayoutPath))
		{
			string pathElementName = "Path";
			XDocument xmlContentModel = XDocument.Load(ideaIndexLayoutPath);
			XElement explicitExcludes = xmlContentModel.XPathSelectElement("/project/component/explicitExcludes");
			bool linksExist = explicitExcludes.Elements(pathElementName).Any((element) => element.Value == linksFolder);
			if(!linksExist)
			{
				XElement newElement = new XElement(pathElementName);
				newElement.Value = linksFolder;
				explicitExcludes.Add(newElement);

				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Encoding = new UTF8Encoding();
				settings.Indent = true;
				using (XmlWriter writer = XmlWriter.Create(ideaIndexLayoutPath, settings ))
				{
					xmlContentModel.Save(writer);
				}
			}
		}

		// create project link directory
		if (!Directory.Exists(instancePath))
		{
			Debug.Log("Create link project at " + instancePath);
			Directory.CreateDirectory(instancePath);
		}

		// link sub-durectories
		for(int i = 0; i < directories.Length; i++)
		{
			string directory = directories[i];
			string symlink = Path.Combine(instancePath, directory);
			string source = Path.Combine(projectPath.FullName, directory);

			if(!Directory.Exists(symlink))
			{
				Debug.Log("Create link at directory " + source + ", to " + symlink);
				CreateSymbolicLink(symlink, source);
			}
		}

		// change service name if need
		string key = "EDITOR_NAME_" + instanceName;
		string keyValue = PlayerPrefs.GetString(key, null);
		if(!PlayerPrefs.HasKey(key) || String.IsNullOrEmpty(keyValue))
		{
			keyValue = Environment.MachineName + "_" + instanceName;
			PlayerPrefs.SetString(key, keyValue);
		}

		// start unity instance
		Debug.Log("Opening link project at " + instancePath);
		Process.Start(unityExe.FullName, $"-projectPath \"{instancePath}\" -buildTarget android");
	}
	
	private static string GetProjectPath()
	{
		return Application.dataPath.Remove(Application.dataPath.Length - 6, 6);
	}
	
	private static void CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName)
	{
		Process process = new Process();
		process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
		process.StartInfo.Verb = "runas";
		process.StartInfo.FileName = "cmd.exe";
		process.StartInfo.UseShellExecute = true;
		process.StartInfo.Arguments = $"/c mklink /D \"{lpSymlinkFileName}\" \"{lpTargetFileName}\"";

		//debug pause
		if(false)
		{
			process.StartInfo.Arguments += " & pause";
		}

		process.Start();
	}
}

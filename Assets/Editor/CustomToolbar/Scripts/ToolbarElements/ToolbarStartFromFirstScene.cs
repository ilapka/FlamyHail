using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityToolbarExtender;

[Serializable]
internal class ToolbarStartFromFirstScene : BaseToolbarElement {
	private static GUIContent startFromFirstSceneBtn;

	public override string NameInList => "[Button] Start from first scene";

	public override void Init() {
		EditorApplication.playModeStateChanged += LogPlayModeState;

		startFromFirstSceneBtn = new GUIContent((Texture2D)AssetDatabase.LoadAssetAtPath($"{GetPackageRootPath}/Editor/CustomToolbar/Icons/LookDevSingle1@2x.png", typeof(Texture2D)), "Start from Preloader");
	}

	protected override void OnDrawInList(Rect position) {

	}

	protected override void OnDrawInToolbar() {
		if (GUILayout.Button(startFromFirstSceneBtn, ToolbarStyles.commandButtonStyle)) {
			if (!EditorApplication.isPlaying) {
				EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
				EditorPrefs.SetString("LastActiveSceneToolbar", EditorSceneManager.GetActiveScene().path);
				EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(0));
			}

			EditorApplication.isPlaying = !EditorApplication.isPlaying;
		}
	}

	private static void LogPlayModeState(PlayModeStateChange state) {
		if (state == PlayModeStateChange.EnteredEditMode && EditorPrefs.HasKey("LastActiveSceneToolbar")) {
			EditorSceneManager.OpenScene(EditorPrefs.GetString("LastActiveSceneToolbar"));
			EditorPrefs.DeleteKey("LastActiveSceneToolbar");
		}
	}
}

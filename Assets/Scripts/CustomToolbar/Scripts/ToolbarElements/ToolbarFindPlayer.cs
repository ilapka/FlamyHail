using System;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

[Serializable]
internal class ToolbarFindPlayer : BaseToolbarElement {
	private static GUIContent findPlayerBtn;

	public override string NameInList => "[Button] Find player";

	public override void Init()
	{
		findPlayerBtn = EditorGUIUtility.TrTextContent("Find player");
	}

	protected override void OnDrawInList(Rect position) {

	}

	protected override void OnDrawInToolbar() {
		if (GUILayout.Button(findPlayerBtn, UnityToolbarExtender.ToolbarStyles.commandButtonTextStyle))
		{
			/*
			var objects = Object.FindObjectsOfType<VehicleController>();
			foreach (VehicleController vehicleController in objects)
			{
				if (vehicleController.NetworkApi.IsMine)
				{
					Selection.activeGameObject = vehicleController.Vehicle.gameObject;
					EditorGUIUtility.PingObject(vehicleController.Vehicle);
					SceneView.FrameLastActiveSceneView();
					break;
				}
			}*/
		}
	}
}

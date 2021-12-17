using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityToolbarExtender
{
    static class ToolbarStyles
    {
        public static readonly GUIStyle commandButtonStyle;
        public static readonly GUIStyle commandButtonTextStyle;

        static ToolbarStyles()
        {
            commandButtonStyle = new GUIStyle("Command")
            {
                fontSize = 16,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold,
				margin = new RectOffset(0,0,0,0),
				padding = new RectOffset(0,0,0,0),
				fixedHeight = 20
            };
			
			commandButtonTextStyle = new GUIStyle("Command")
            {
                fontSize = 12,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold,
				fixedWidth = 80,
				margin = new RectOffset(0,0,0,0),
				padding = new RectOffset(0,0,0,0),
				fixedHeight = 20
            };
        }
    }
}
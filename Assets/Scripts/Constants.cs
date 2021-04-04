using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public static class Constants
    {
        public static readonly Color ToolbarButtonIdleColor = Color.white - new Color32(50, 50, 50, 0);
        public static readonly Color ToolbarButtonHoverColor = Color.white - new Color32(100, 100, 100, 0);
        public static readonly Color ToolbarButtonClickedColor = Color.green;
        public static readonly Vector3 ToolbarButtonClickTranslation = new Vector3(-0.1f, 0, 0);
        public const string MouseScrollWheel = "Mouse ScrollWheel";
    }
}

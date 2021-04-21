using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class UserData : MonoBehaviour
    {
        [SerializeField]
        private Texture2D selectionCursor;
        [SerializeField]
        private Texture2D boxCursor = default;
        public static UserData Instance { get; private set; }
        private ToolMode toolMode;
        public ToolMode ToolMode
        {
            get
            {
                return toolMode;
            }
            set
            {
                toolMode = value;
                switch (value)
                {
                    case ToolMode.Selection:
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                        break;
                    }
                    case ToolMode.Box:
                    {
                        Cursor.SetCursor(boxCursor, new Vector2(boxCursor.width / 2, boxCursor.height / 2), CursorMode.Auto);
                        break;
                    }
                    case ToolMode.Line:
                    {
                        Cursor.SetCursor(boxCursor, new Vector2(boxCursor.width / 2, boxCursor.height / 2), CursorMode.Auto);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// The current <see cref="SnapPointInfo"/>. If the cursor isn't on any snap points, <see cref="SnapPointInfo.SnappedPosition"/> will be set to <see cref="Input.mousePosition"/> and <see cref="SnapPointInfo.SnappedGameObject"/> will be set to <see langword="null"/>.
        /// </summary>
        public SnapPointInfo SnapPointInfo { get; set; }

        private void Start()
        {
            Instance = this;
        }
    }
}

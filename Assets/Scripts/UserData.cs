using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    [SerializeField]
    private Texture2D selectionCursor;
    [SerializeField]
    private Texture2D boxCursor = default;
    public static UserData Instance { get; set; }
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
                    Cursor.SetCursor(null, Vector2.zero, UnityEngine.CursorMode.Auto);
                    break;
                }
                case ToolMode.Box:
                {
                    Cursor.SetCursor(boxCursor, new Vector2(boxCursor.width / 2, boxCursor.height / 2), UnityEngine.CursorMode.Auto);
                    break;
                }
                case ToolMode.Line:
                {
                    Cursor.SetCursor(boxCursor, new Vector2(boxCursor.width / 2, boxCursor.height / 2), UnityEngine.CursorMode.Auto);
                    break;
                }
            }
        }
    }

    private void Start()
    {
        Instance = this;
    }
}

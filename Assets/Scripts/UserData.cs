using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    [SerializeField]
    private Texture2D selectionCursor;
    [SerializeField]
    private Texture2D boxCursor;
    public static UserData Instance { get; set; }
    private CursorMode cursorMode;
    public CursorMode CursorMode
    {
        get
        {
            return cursorMode;
        }
        set
        {
            cursorMode = value;
            switch (value)
            {
                case CursorMode.Selection:
                {
                    Cursor.SetCursor(null, Vector2.zero, UnityEngine.CursorMode.Auto);
                    break;
                }
                case CursorMode.Box:
                {
                    Cursor.SetCursor(boxCursor, new Vector2(boxCursor.width / 2, boxCursor.height / 2), UnityEngine.CursorMode.Auto);
                    break;
                }
            }
        }
    }

    private void Start()
    {
        Instance = GetComponent<UserData>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour
{
    public static Toolbar Instance { get; set; }
    [SerializeField]
    private GameObject content;

    private void Start()
    {
        Instance = GetComponent<Toolbar>();
    }

    public void ActivateItem(IToolbarItem item)
    {
        if (!item.IsActive)
        {
            foreach (Transform transform in content.transform)
            {
                IToolbarItem iti = transform.gameObject.GetComponent<IToolbarItem>();
                iti?.Deactivate();
            }
            item.GameObject.transform.Translate(Constants.ToolbarButtonClickTranslation);
            item.IsActive = true;
            item.Background.color = Constants.ToolbarButtonClickedColor;
            UserData.Instance.CursorMode = item.ToolMode;
        }
    }

    public void DeactivateItem(IToolbarItem item)
    {
        if (item.IsActive)
        {
            item.GameObject.transform.Translate(-Constants.ToolbarButtonClickTranslation);
            item.IsActive = false;
            item.Background.color = Constants.ToolbarButtonIdleColor;
            UserData.Instance.CursorMode = ToolMode.Selection;
        }
    }
}

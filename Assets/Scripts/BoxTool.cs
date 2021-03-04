using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxTool : MonoBehaviour, IToolbarItem
{
    public static BoxTool Instance { get; set; }
    public bool IsActive { get; set; }
    public GameObject GameObject { get; private set; }

    public Image Background { get; set; }
    public ToolMode ToolMode { get; private set; } = ToolMode.Box;
    private bool isFirstClick = true;

    private void Start()
    {
        Instance = GetComponent<BoxTool>();
        Background = GetComponent<Image>();
        Background.color = Constants.ToolbarButtonIdleColor;
        GameObject = gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            Activate();
        }    
        else
        {
            Deactivate();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            Background.color = Constants.ToolbarButtonHoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            Background.color = Constants.ToolbarButtonIdleColor;
        }
    }

    public void Activate()
    {
        Toolbar.Instance.ActivateItem(this);
        isFirstClick = false;
    }

    public void Deactivate()
    {
        Toolbar.Instance.DeactivateItem(this);
        isFirstClick = true;
    }
}


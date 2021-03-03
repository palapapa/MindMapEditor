using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxTool : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image background;
    private bool isFirstClick = true;
    private Color clickColor = Color.green;
    private Color idleColor = Color.white - new Color32(50, 50, 50, 0);
    private Color hoverColor = Color.white - new Color32(100, 100, 100, 0);
    private Vector3 clickTranslate = new Vector3(-0.1f, 0, 0);

    private void Start()
    {
        background = GetComponent<Image>();
        background.color = idleColor;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            gameObject.transform.Translate(clickTranslate);
            background.color = clickColor;
            UserData.Instance.CursorMode = CursorMode.Box;
            isFirstClick = false;
        }    
        else
        {
            gameObject.transform.Translate(-clickTranslate);
            background.color = idleColor;
            UserData.Instance.CursorMode = CursorMode.Selection;
            isFirstClick = true;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            background.color = hoverColor;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (isFirstClick)
        {
            background.color = idleColor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ToolBarItemBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected bool IsActive { get; set; } = false;

    protected GameObject GameObject { get; set; }

    protected Image Background { get; set; }

    [SerializeField]
    protected ToolMode ToolMode;

    private void Start()
    {
        Background = GetComponent<Image>();
        Background.color = Constants.ToolbarButtonIdleColor;
        GameObject = gameObject;
    }

    protected void Activate()
    {
        if (!IsActive)
        {
            foreach (Transform transform in transform.parent)
            {
                ToolBarItemBase tbib = transform.gameObject.GetComponent<ToolBarItemBase>();
                if (tbib != null)
                {
                    tbib.Deactivate();
                }
            }
            GameObject.transform.Translate(Constants.ToolbarButtonClickTranslation);
            IsActive = true;
            Background.color = Constants.ToolbarButtonClickedColor;
            UserData.Instance.ToolMode = ToolMode;
        }
    }

    protected void Deactivate()
    {
        if (IsActive)
        {
            GameObject.transform.Translate(-Constants.ToolbarButtonClickTranslation);
            IsActive = false;
            Background.color = Constants.ToolbarButtonIdleColor;
            UserData.Instance.ToolMode = ToolMode.Selection;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsActive)
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
        if (!IsActive)
        {
            Background.color = Constants.ToolbarButtonHoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsActive)
        {
            Background.color = Constants.ToolbarButtonIdleColor;
        }
    }
}

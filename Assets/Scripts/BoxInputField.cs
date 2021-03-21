using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[AddComponentMenu("Custom/BoxInputField")]
public class BoxInputField : TMP_InputField
{
    private GameObject caret;

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.clickCount);
        if (eventData.clickCount == 2)
        {
            caret.SetActive(true);
            ActivateInputField();
            m_CaretSelectPosition = 0;
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        caret.SetActive(false);
    }

    protected override void Start()
    {
        caret = Utilities.RecursiveFindChild(transform, "Caret").gameObject;
    }
}

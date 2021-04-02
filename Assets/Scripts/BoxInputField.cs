using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace MindMapEditor
{
    [AddComponentMenu("Custom/BoxInputField")]
    public class BoxInputField : TMP_InputField
    {
        private GameObject caret;
        private bool isFirstDoubleClick = true;

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                caret.SetActive(true);
                ActivateInputField();
                if (isFirstDoubleClick)
                {
                    MoveTextEnd(false);
                    caretPosition = text.Length;
                    isFirstDoubleClick = false;
                }
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {

        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            caret.SetActive(false);
            isFirstDoubleClick = true;
        }

        protected override void Start()
        {
            caret = Utilities.RecursiveFindChild(transform, "Caret").gameObject;
        }
    }
}

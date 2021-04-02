using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MindMapEditor
{
    public class Background : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public static Background Instance { get; private set; }
        public bool IsMouseOnBackground { get; private set; } = false;

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsMouseOnBackground = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsMouseOnBackground = false;
        }

        void Start()
        {
            Instance = this;
        }
    }
}

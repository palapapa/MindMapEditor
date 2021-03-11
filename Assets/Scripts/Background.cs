using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Background : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Background Instance { get; set; }
    public bool IsMouseOnBackground { get; set; } = false;

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

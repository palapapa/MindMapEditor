using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Box : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsMouseOnBox { get; private set; } = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOnBox = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseOnBox = false;
    }
}

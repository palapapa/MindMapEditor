using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Toolbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Toolbar Instance { get; private set; }
    public bool IsMouseOnToolbar { get; private set; } = false;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOnToolbar = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseOnToolbar = false;
    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToolbarItem.DeactivateAll();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragSelection : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private DragRectDrawer dragRectDrawer = new DragRectDrawer();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        dragRectDrawer.DrawRect(lineRenderer, Input.GetKey(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Selection && Background.Instance.IsMouseOnBackground);
    }
}

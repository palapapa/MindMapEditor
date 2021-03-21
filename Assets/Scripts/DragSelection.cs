using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragSelection : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private DragRectDrawer dragRectDrawer = new DragRectDrawer();
    private bool isFirstClick = true;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        bool isDraw = Input.GetKey(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Selection && !Toolbar.Instance.IsMouseOnToolbar;
        if (isDraw)
        {
            if (isFirstClick) // so that the selection box is only drawable starting from outside of a box
            {
                if (!Boxes.Instance.IsMouseOnAnyBox())
                {
                    dragRectDrawer.DrawRect(lineRenderer, isDraw);
                    isFirstClick = false;
                }
            }
            else
            {
                dragRectDrawer.DrawRect(lineRenderer, isDraw);
            }
        }
        else
        {
            dragRectDrawer.DrawRect(lineRenderer, false); // force reset the drawer
            isFirstClick = true;
        }
    }
}

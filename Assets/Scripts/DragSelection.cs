using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MindMapEditor
{
    public class DragSelection : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private DragRectDrawer dragRectDrawer;
        private bool isFirstClick = true;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            dragRectDrawer = new DragRectDrawer(lineRenderer);
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
                        dragRectDrawer.DrawRect(isDraw, false);
                        isFirstClick = false;
                    }
                }
                else
                {
                    dragRectDrawer.DrawRect(isDraw, false);
                }
            }
            else
            {
                dragRectDrawer.DrawRect(false, false); // force reset the drawer
                isFirstClick = true;
            }
        }
    }
}

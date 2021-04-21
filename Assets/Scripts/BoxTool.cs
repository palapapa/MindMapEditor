using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MindMapEditor
{
    public class BoxTool : MonoBehaviour
    {
        [SerializeField]
        private GameObject box = default;
        [SerializeField]
        private GameObject boxes = default;
        [SerializeField]
        private Canvas canvas = default;
        private LineRenderer lineRenderer;
        private DragRectDrawer dragRectDrawer;
        private Vector3 lastMousePosition;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            dragRectDrawer = new DragRectDrawer(lineRenderer);
        }

        private void Update()
        {
            dragRectDrawer.DrawRect(Input.GetKey(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Box && !Toolbar.Instance.IsMouseOnToolbar, true);
            if (Input.GetKeyUp(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Box && lastMousePosition == dragRectDrawer.EndPosition)
            {
                Vector3 start = Utilities.ScreenToWorldPoint2D(dragRectDrawer.SnappedStartPosition);
                Vector3 end = Utilities.ScreenToWorldPoint2D(dragRectDrawer.SnappedEndPosition);
                Vector3 direction = end - start;
                if (direction.x == 0 || direction.y == 0)
                {
                    return;
                }
                Vector3 originalStart = start;
                Vector3 originalEnd = end;
                GameObject newBox = Instantiate(box, boxes.transform);
                RectTransform rectTransform = newBox.GetComponent<RectTransform>();
                rectTransform.pivot = Vector2.zero;
                if (direction.x < 0 && direction.y > 0) // quadrant 2
                {
                    start = new Vector3(originalEnd.x, originalStart.y, 0);
                    end = new Vector3(originalStart.x, originalEnd.y, 0);
                }
                else if (direction.x < 0 && direction.y < 0) // quadrant 3
                {
                    Utilities.Swap(ref start, ref end);
                }
                else if (direction.x > 0 && direction.y < 0) // quadrant 4
                {
                    start = new Vector3(originalStart.x, originalEnd.y, 0);
                    end = new Vector3(originalEnd.x, originalStart.y, 0);
                }
                else
                {
                    if (!(direction.x > 0 && direction.y > 0)) // on axis(this might be unreachable since if it were on axis Update would have returned)
                    {
                        if (start.x > end.x || start.y > end.y)
                        {
                            Utilities.Swap(ref start, ref end);
                        }
                    }
                }
                rectTransform.position = start;
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, end.x - start.x);
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, end.y - start.y);
                rectTransform.localScale = canvas.transform.localScale.GetReciprocal();
            }
        }

        private void LateUpdate()
        {
            lastMousePosition = Input.mousePosition;
        }
    }
}

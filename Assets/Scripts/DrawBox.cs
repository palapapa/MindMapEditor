﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBox : MonoBehaviour
{
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private GameObject mapObjects;
    private LineRenderer lineRenderer;
    private DragRectDrawer dragRectDrawer = new DragRectDrawer();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        dragRectDrawer.DrawRect(lineRenderer, Input.GetKey(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Box && Background.Instance.IsMouseOnBackground);
        if (Input.GetKeyUp(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Box && Background.Instance.IsMouseOnBackground)
        {
            GameObject newBox = Instantiate(box, mapObjects.transform);
            RectTransform rectTransform = newBox.GetComponent<RectTransform>();
            rectTransform.pivot = Vector2.zero;
            Vector3 start = Utilities.ScreenToWorldPoint2D(dragRectDrawer.StartPosition);
            Vector3 end = Utilities.ScreenToWorldPoint2D(dragRectDrawer.EndPosition);
            Vector3 direction = end - start;
            Vector3 originalStart = start;
            Vector3 originalEnd = end;
            if (direction.x < 0 && direction.y > 0) // quadrant 2
            {
                start = new Vector3(originalEnd.x, originalStart.y, 0);
                end = new Vector3(originalStart.x, originalEnd.y, 0);
            }
            else if (direction.x < 0 && direction.y < 0) // quadrant 3
            {
                Utilities.Swap(ref start, ref end);
            }
            else if(direction.x > 0 && direction.y < 0) // quadrant 4
            {
                start = new Vector3(originalStart.x, originalEnd.y, 0);
                end = new Vector3(originalEnd.x, originalStart.y, 0);
            }
            else
            {
                if (!(direction.x > 0 && direction.y > 0)) // on axis
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
        }
    }
}
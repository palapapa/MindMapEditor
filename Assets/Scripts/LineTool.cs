﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MindMapEditor
{
    public class LineTool : MonoBehaviour
    {
        [SerializeField]
        private GameObject line = default;
        [SerializeField]
        private GameObject lines = default;
        private LineRenderer lineRenderer;
        private bool isFirstClick = true;
        private Vector3 startPosition = new Vector3();
        private Vector3 endPosition = new Vector3();

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.widthMultiplier = 0.1f;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Line && !Toolbar.Instance.IsMouseOnToolbar)
            {
                if (isFirstClick)
                {
                    startPosition = UserData.Instance.SnapPointInfo.SnappedPosition;
                    isFirstClick = false;
                }
                else
                {
                    endPosition = UserData.Instance.SnapPointInfo.SnappedPosition;
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPositions(new Vector3[2] { Utilities.ScreenToWorldPoint2D(startPosition), Utilities.ScreenToWorldPoint2D(endPosition) });
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && UserData.Instance.ToolMode == ToolMode.Line)
            {
                lineRenderer.positionCount = 0;
                if (startPosition != endPosition)
                {
                    GameObject newLine = Instantiate(line);
                    newLine.transform.SetParent(lines.transform);
                    RectTransform rectTransform = newLine.GetComponent<RectTransform>();
                    rectTransform.pivot = new Vector2(0, 0.5f);
                    Vector3 direction = Utilities.ScreenToWorldPoint2D(endPosition) - Utilities.ScreenToWorldPoint2D(startPosition);
                    newLine.transform.position = Utilities.ScreenToWorldPoint2D(startPosition);
                    rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, direction.magnitude);
                    float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);
                    newLine.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                isFirstClick = true;
                startPosition = Vector3.zero;
                endPosition = Vector3.zero;
            }
        }
    }
}

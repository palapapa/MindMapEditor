using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRectDrawer
{
    /// <summary>
    /// <see langword="false"/> when a rectangle is being drawn, <see langword="true"/> when not.
    /// </summary>
    public bool IsFirstClick { get; private set; } = true;
    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }

    /// <summary>
    /// When <paramref name="condition"/> is <see langword="true"/>, draws a rectangle at the mouse's position. The rectangle updates on every call.
    /// </summary>
    /// <param name="lineRenderer">The line renderer used to draw the rect.</param>
    /// <param name="condition">When <see langword="true""/>, draw the rect. When <see langword="false"/>, reset the rect.</param>
    public void DrawRect(LineRenderer lineRenderer, bool condition)
    {
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numCapVertices = 16;
        lineRenderer.numCornerVertices = 16;
        if (condition)
        {
            if (IsFirstClick)
            {
                StartPosition = Input.mousePosition;
                IsFirstClick = false;
            }
            else
            {
                EndPosition = Input.mousePosition;
                List<Vector3> positions = new List<Vector3>
                {
                    StartPosition,
                    new Vector3(StartPosition.x, EndPosition.y, 0),
                    EndPosition,
                    new Vector3(EndPosition.x, StartPosition.y, 0),
                    StartPosition
                };
                positions = Utilities.CalculateIntermidiatePoints(positions, 10);
                for (int i = 0; i < positions.Count; i++)
                {
                    positions[i] = Utilities.ScreenToWorldPoint2D(positions[i]);
                }
                lineRenderer.positionCount = positions.Count;
                lineRenderer.SetPositions(positions.ToArray());
            }
        }
        else
        {
            IsFirstClick = true;
            lineRenderer.positionCount = 0;
        }
    }
}

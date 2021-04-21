using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class DragRectDrawer
    {
        /// <summary>
        /// <see langword="false"/> when a rectangle is being drawn, <see langword="true"/> when not.
        /// </summary>
        public bool IsFirstClick { get; private set; } = true;

        /// <summary>
        /// Updated when <see cref="DrawRect(bool, bool, float, int, int)"/> is called. Reset when a new rect is being drawn.
        /// </summary>
        public Vector3 StartPosition { get; private set; }

        /// <summary>
        /// Updated when <see cref="DrawRect(bool, bool, float, int, int)"/> is called. Reset when a new rect is being drawn.
        /// </summary>
        public Vector3 EndPosition { get; private set; }

        /// <summary>
        /// The snapped start position of the mouse. Updated when <see cref="DrawRect(bool, bool, float, int, int)"/> is called. Reset when a new rect is being drawn.
        /// </summary>
        public Vector3 SnappedStartPosition { get; private set; }

        /// <summary>
        /// The snapped end position of the mouse. Updated when <see cref="DrawRect(bool, bool, float, int, int)"/> is called. Reset when a new rect is being drawn.
        /// </summary>
        public Vector3 SnappedEndPosition { get; private set; }

        /// <summary>
        /// The <see cref="LineRenderer"/> used to draw rects.
        /// </summary>
        public LineRenderer LineRenderer { get; set; }

        /// <summary>
        /// When <paramref name="condition"/> is <see langword="true"/>, draws a rectangle at the mouse's position. The rectangle updates on every call.<br/>
        /// Updates <see cref="StartPosition"/>, <see cref="EndPosition"/>, <see cref="SnappedStartPosition"/>, <see cref="SnappedEndPosition"/> on the first(the next call after <paramref name="condition"/> was false) call.<br/>
        /// Updates <see cref="EndPosition"/>, <see cref="SnappedEndPosition"/> on subsequent calls.<br/>
        /// </summary>
        /// <param name="condition">When <see langword="true"/>, draw the rect. When <see langword="false"/>, reset the rect.</param>
        /// <param name="snapped">Whether to use the snapped mouse position to draw the rect. Regardless of this parameter, <see cref="SnappedStartPosition"/> and <see cref="SnappedEndPosition"/> will still be updated.</param>
        public void DrawRect(bool condition, bool snapped, float width = 0.1f, int numCapVertices = 16, int numCornerVertices = 16)
        {
            LineRenderer.widthMultiplier = width;
            LineRenderer.numCapVertices = numCapVertices;
            LineRenderer.numCornerVertices = numCornerVertices;
            if (condition)
            {
                if (IsFirstClick)
                {
                    StartPosition = Input.mousePosition;
                    EndPosition = Input.mousePosition;
                    SnappedStartPosition = UserData.Instance.SnapPointInfo.SnappedPosition;
                    SnappedEndPosition = UserData.Instance.SnapPointInfo.SnappedPosition;
                    IsFirstClick = false;
                }
                else
                {
                    EndPosition = Input.mousePosition;
                    SnappedEndPosition = UserData.Instance.SnapPointInfo.SnappedPosition;
                    List<Vector3> positions;
                    if (snapped)
                    {
                        positions = new List<Vector3>
                        {
                            SnappedStartPosition,
                            new Vector3(SnappedStartPosition.x, SnappedEndPosition.y, 0),
                            SnappedEndPosition,
                            new Vector3(SnappedEndPosition.x, SnappedStartPosition.y, 0),
                            SnappedStartPosition
                        };
                    }
                    else
                    {
                        positions = new List<Vector3>
                        {
                            StartPosition,
                            new Vector3(StartPosition.x, EndPosition.y, 0),
                            EndPosition,
                            new Vector3(EndPosition.x, StartPosition.y, 0),
                            StartPosition
                        };
                    }
                    positions = Utilities.CalculateIntermidiatePoints(positions, 10);
                    for (int i = 0; i < positions.Count; i++)
                    {
                        positions[i] = Utilities.ScreenToWorldPoint2D(positions[i]);
                    }
                    LineRenderer.positionCount = positions.Count;
                    LineRenderer.SetPositions(positions.ToArray());
                }
            }
            else
            {
                IsFirstClick = true;
                LineRenderer.positionCount = 0;
            }
        }

        public DragRectDrawer(LineRenderer lineRenderer)
        {
            LineRenderer = lineRenderer;
        }
    }
}

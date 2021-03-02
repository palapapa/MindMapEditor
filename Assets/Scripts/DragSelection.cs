using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragSelection : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isFirstClick = true;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numCapVertices = 16;
        lineRenderer.numCornerVertices = 16;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isFirstClick)
            {
                startPosition = Input.mousePosition;
                isFirstClick = false;
            }
            else
            {
                endPosition = Input.mousePosition;
                List<Vector3> positions = new List<Vector3>
                {
                    startPosition,
                    new Vector3(startPosition.x, endPosition.y, 0),
                    endPosition,
                    new Vector3(endPosition.x, startPosition.y, 0),
                    startPosition
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
            isFirstClick = true;
            lineRenderer.positionCount = 0;
        }
    }
}

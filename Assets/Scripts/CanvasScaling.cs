using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class CanvasScaling : MonoBehaviour
    {
        private readonly float zoomAmount = 1.1f;

        private void Update()
        {
            if (Input.GetAxis(Constants.MouseScrollWheel) > 0 && Camera.main.orthographicSize - zoomAmount > 0)
            {
                MapObjects.Instance.gameObject.transform.localScale *= zoomAmount;
                /*
                canvas.transform.position = Vector3.Lerp
                (
                    -canvas.transform.position,
                    Utilities.ScreenToWorldPoint2D(Input.mousePosition),
                    zoomAmount - 1
                );
                */ // zoom gradually closer to mouse position, will implement later
            }
            else if (Input.GetAxis(Constants.MouseScrollWheel) < 0)
            {
                MapObjects.Instance.gameObject.transform.localScale /= zoomAmount;
            }
        }
    }
}

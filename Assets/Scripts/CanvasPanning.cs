using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class CanvasPanning : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas = default;
        private Vector3 startPosition = new Vector3();
        private Vector3 endPosition = new Vector3();
        private bool isFirstClick = true;

        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse1) && !Toolbar.Instance.IsMouseOnToolbar)
            {
                if (isFirstClick)
                {
                    startPosition = Utilities.ScreenToWorldPoint2D(Input.mousePosition);
                    isFirstClick = false;
                }
                else
                {
                    endPosition = Utilities.ScreenToWorldPoint2D(Input.mousePosition);
                    canvas.transform.Translate(endPosition - startPosition);
                    startPosition = endPosition;
                }
            }
            else
            {
                isFirstClick = true;
            }
        }
    }
}

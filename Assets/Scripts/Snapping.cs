using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MindMapEditor
{
    public class Snapping : MonoBehaviour
    {
        [SerializeField]
        private Image snapPointImage = default;
        private float snappingDetectionRange;

        private void Start()
        {
            snapPointImage.gameObject.SetActive(false);
            snappingDetectionRange = snapPointImage.GetComponent<RectTransform>().rect.width;
        }

        private void Update()
        {
            UpdateAllSnapPoints(MapObjects.Instance.gameObject.transform);
            UserData.Instance.SnapPointInfo = GetSnapPointInfo(Input.mousePosition, MapObjects.Instance.gameObject.transform);
        }

        /// <summary>
        /// Returns the <see cref="SnapPointInfo"/> corresponding to the snap point the mouse is currently on. If the mouse isn't on any snap point, returns <see langword="null"/>. <br />
        /// The check is done recursively and isn't performed on the parents.
        /// </summary>
        /// <param name="mousePosition">The screen position of the mouse.</param>
        /// <param name="parent">The parent transforms that the snap point check is performed on.</param>
        /// <returns></returns>
        private SnapPointInfo GetSnapPointInfo(Vector3 mousePosition, Transform parent)
        {
            Transform[] children = parent.GetComponentsInChildren<Transform>();
            foreach (Transform transform in children)
            {
                ISnapPoint iSnapPoint = transform.GetComponent<ISnapPoint>();
                if (iSnapPoint != null)
                {
                    foreach (Vector3 snapPoint in iSnapPoint.SnapPoints)
                    {
                        if (Vector3.Distance(Utilities.ScreenToWorldPoint2D(mousePosition), snapPoint) <= snappingDetectionRange)
                        {
                            snapPointImage.gameObject.SetActive(true);
                            snapPointImage.transform.position = snapPoint;
                            return new SnapPointInfo(transform.gameObject, snapPoint);
                        }
                    }
                }
            }
            snapPointImage.gameObject.SetActive(false);
            return null;
        }

        private void UpdateAllSnapPoints(Transform parent)
        {
            Transform[] children = parent.GetComponentsInChildren<Transform>();
            foreach (Transform transform in children)
            {
                ISnapPoint iSnapPoint = transform.GetComponent<ISnapPoint>();
                if (iSnapPoint != null)
                {
                    iSnapPoint.UpdateSnapPoints();
                }
            }
        }
    }
}

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
            snappingDetectionRange = 0.15f;
        }

        private void Update()
        {
            UpdateAllSnapPoints(MapObjects.Instance.gameObject.transform);
            UserData.Instance.SnapPointInfo = GetSnapPointInfo(Input.mousePosition, MapObjects.Instance.gameObject.transform);
        }

        /// <summary>
        /// Returns the <see cref="SnapPointInfo"/> corresponding to the snap point the mouse is currently on. If the mouse isn't on any snap point, <see cref="SnapPointInfo.SnappedPosition"/> will be set to <see cref="Input.mousePosition"/> and <see cref="SnapPointInfo.SnappedGameObject"/> will be set to <see langword="null"/>. <br />
        /// The check is done recursively and isn't performed on the parents.
        /// </summary>
        /// <param name="mousePosition">The screen position of the mouse.</param>
        /// <param name="parent">The parent transform that the snap point check is performed on.</param>
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
                            return new SnapPointInfo(Camera.main.WorldToScreenPoint(snapPoint), transform.gameObject);
                        }
                    }
                }
            }
            snapPointImage.gameObject.SetActive(false);
            return new SnapPointInfo(Input.mousePosition, null);
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

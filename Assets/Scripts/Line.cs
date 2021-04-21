using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class Line : MonoBehaviour, ISnapPoint
    {
        public List<Vector3> SnapPoints { get; private set; }
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            UpdateSnapPoints();
        }

        public void UpdateSnapPoints()
        {
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            SnapPoints = new List<Vector3>
            {
                (worldCorners[0] + worldCorners[1]) / 2,
                (worldCorners[2] + worldCorners[3]) / 2
            };
        }
    }
}

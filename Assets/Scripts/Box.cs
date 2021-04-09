using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace MindMapEditor
{
    public class Box : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISnapPoint
    {
        public bool IsMouseOnBox { get; private set; } = false;
        public List<Vector3> SnapPoints { get; private set; }
        private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            UpdateSnapPoints();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsMouseOnBox = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsMouseOnBox = false;
        }

        public void UpdateSnapPoints()
        {
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            SnapPoints = new List<Vector3>
            {
                worldCorners[0],
                worldCorners[1],
                worldCorners[2],
                worldCorners[3],
                (worldCorners[0] + worldCorners[1]) / 2,
                (worldCorners[1] + worldCorners[2]) / 2,
                (worldCorners[2] + worldCorners[3]) / 2,
                (worldCorners[3] + worldCorners[0]) / 2
            };
        }
    }
}

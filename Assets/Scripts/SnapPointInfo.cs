using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public class SnapPointInfo
    {
        /// <summary>
        /// The <see cref="GameObject"/> which the mouse is snapped onto.
        /// </summary>
        public GameObject SnappedGameObject { get; set; }
        /// <summary>
        /// The position the mouse is snapped to.
        /// </summary>
        public Vector3 SnapPosition { get; set; }

        public SnapPointInfo(GameObject snappedGameObject, Vector3 snapPosition)
        {
            SnappedGameObject = snappedGameObject;
            SnapPosition = snapPosition;
        }
    }
}
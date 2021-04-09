using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public interface ISnapPoint
    {
        public List<Vector3> SnapPoints { get; }
        public void UpdateSnapPoints();
    }
}
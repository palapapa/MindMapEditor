using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MindMapEditor
{
    public static class Utilities
    {
        /// <summary>
        /// Calls <see cref="Camera.ScreenToWorldPoint(Vector3)"/> on <paramref name="position"/> then set the resulting <see cref="Vector3.z"/> to 0.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector3 ScreenToWorldPoint2D(Vector3 position)
        {
            Vector3 result = Camera.main.ScreenToWorldPoint(position);
            result = new Vector3(result.x, result.y, 0);
            return result;
        }

        /// <summary>
        /// Generate intermidiate points between <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count">The number of points to generate(including <paramref name="start"/> and <paramref name="end"/>).</param>
        /// <returns></returns>
        public static List<Vector3> CalculateIntermidiatePoints(Vector3 start, Vector3 end, int count)
        {
            if (count < 2)
            {
                throw new ArgumentException("Can't be less than 2", nameof(count));
            }
            List<Vector3> result = new List<Vector3>();
            for (int i = 0; i < count; i++)
            {
                result.Add(Vector3.Lerp(start, end, 1.0f / count * i));
            }
            return result;
        }

        /// <summary>
        /// Generate intermidiate points between each <paramref name="vector3s"/>.
        /// </summary>
        /// <param name="vector3s"></param>
        /// <param name="count">The number of points to generate between each <paramref name="vector3s"/>(including each pair of <paramref name="vector3s"/>).</param>
        /// <returns></returns>
        public static List<Vector3> CalculateIntermidiatePoints(List<Vector3> vector3s, int count)
        {
            if (count < 2)
            {
                throw new ArgumentException("Can't be less than 2", nameof(count));
            }
            List<Vector3> result = new List<Vector3>();
            for (int i = 0; i < vector3s.Count - 1; i++)
            {
                if (i != 0)
                {
                    result.RemoveAt(result.Count - 1);
                }
                for (int j = 0; j < count; j++)
                {
                    result.Add(Vector3.Lerp(vector3s[i], vector3s[i + 1], 1.0f / count * j));
                }
            }
            result.RemoveAt(result.Count - 1);
            result.Add(vector3s.Last()); // to eliminate float arithmetic inaccuracy
            return result;
        }

        public static T Last<T>(this IList<T> list)
        {
            return list[list.Count - 1];
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static Transform RecursiveFindChild(Transform parent, string childName)
        {
            foreach (Transform child in parent)
            {
                if (child.name == childName)
                {
                    return child;
                }
                else
                {
                    Transform found = RecursiveFindChild(child, childName);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }
    }
}

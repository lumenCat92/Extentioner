using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LumenCat92.Extentioner
{
    public static class Vector3Extentioner
    {
        public static float GetRotationDir(this Vector3 from, Vector3 to)
        {
            var rotateDir = Vector3.Angle(from, to);
            Vector3 crossProduct = Vector3.Cross(from, to);
            float dotProduct = Vector3.Dot(crossProduct, Vector3.up);
            var dirABS = dotProduct >= 0 ? 1 : -1;

            return rotateDir * dirABS;
        }
        public static Vector3 GetDirection(this Vector3 from, Vector3 to) => (to - from).normalized;
        public static float GetDistance(this Vector3 from, Vector3 to) => Vector3.Distance(from, to);
        public static Vector3 GetOverrideX(this Vector3 original, float x) => new Vector3(x, original.y, original.z);
        public static Vector3 GetOverrideY(this Vector3 original, float y) => new Vector3(original.x, y, original.z);
        public static Vector3 GetOverrideZ(this Vector3 original, float z) => new Vector3(original.x, original.y, z);
    }
}

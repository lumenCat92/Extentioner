using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LumenCat92.Extentioner
{
    public static class TransformExtentioner
    {
        public static float GetDist(this Transform center, Transform to) => center.position.GetDistance(to.position);
        public static Vector3 GetDirection(this Transform center, Transform to) => center.position.GetDirection(to.position);
        public static List<RaycastHit> GetRayCastAll(this Transform center, Transform target)
        {
            return center.position.RayCastAll(target.position);
        }

        public static List<RaycastHit> GetRayCastAll(this Transform center, Vector3 dir, float dist)
        {
            return center.position.RayCastAll(dir, dist);
        }

        public static bool IsRayHitToTarget(this Transform center, Transform target, out RaycastHit hit, float dist, float limitedAngle = 180f)
        {
            hit = default;
            var allHits = center.GetRayCastAll(center.GetDirection(target), dist);
            allHits = allHits.Where(x => !x.transform.IsChildOf(center.root)).ToList();
            if (allHits.Count > 0)
            {
                hit = allHits[0];

                var angle = Vector3.Angle(center.forward, center.position.GetDirection(hit.point));
                if (angle <= limitedAngle)
                {
                    return hit.transform.CompareTag(target.tag);
                }
            }

            return false;
        }

        public static List<Collider> GetOverlapSphere(this Transform target, float radius)
        {
            return target.position.GetOverlapSphere(radius);
        }
    }
}

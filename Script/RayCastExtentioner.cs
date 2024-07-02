using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

namespace LumenCat92.Extentioner
{
    public static class RayCastExtentioner
    {
        public static List<RaycastHit> GetAllRayHitWithAngle(this Vector3 center, Vector3 forward, float dist, float limitedAngle, float eachAngle)
        {
            var list = new List<RaycastHit>();
            for (float nowAngle = 0; nowAngle <= limitedAngle; nowAngle += eachAngle)
            {
                var leftAngle = Quaternion.Euler(0f, nowAngle, 0) * forward;
                var RightAngle = Quaternion.Euler(0f, -nowAngle, 0) * forward;

                var leftHit = Physics.RaycastAll(center, leftAngle, dist);
                var rightHit = Physics.RaycastAll(center, RightAngle, dist);
                for (int i = 0; i < 2; i++)
                {
                    var targetList = i == 0 ? leftHit : rightHit;
                    foreach (var item in targetList)
                    {
                        if (!list.Contains(item))
                        {
                            list.Add(item);
                        }
                    }
                }
            }

            list.OrderBy(x => Vector3.Distance(center, x.point));
            return list;
        }

        public static bool RayCast(this Vector3 position, Vector3 dir, out RaycastHit hit)
        {
            var ray = new Ray(position, dir);
            var isHit = Physics.Raycast(ray, out hit);

            return isHit;
        }

        public static List<RaycastHit> RayCastAll(this Vector3 position, Vector3 endPoint)
        {
            var dir = position.GetDirection(endPoint);
            var dist = position.GetDistance(endPoint);

            return RayCastAll(position, dir, dist);
        }

        public static List<RaycastHit> RayCastAll(this Vector3 position, Vector3 dir, float dist)
        {
            return Physics.RaycastAll(position, dir, dist).ToList();
        }

        public static List<Collider> GetOverlapSphere(this Vector3 position, float radius)
        {
            return Physics.OverlapSphere(position, radius).ToList();
        }
    }
}
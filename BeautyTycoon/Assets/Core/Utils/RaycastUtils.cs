using UnityEngine;

namespace BT.Core.Utils
{
    public class RaycastTarget : MonoBehaviour { }

    public static class RaycastUtils
    {
        private static readonly RaycastHit2D[] _cache = new RaycastHit2D[5];

        public static Transform Raycast2DScreenSpace<T>
            (this Camera camera, Vector2 screenPoint, int layer)
            where T : RaycastTarget
        {
            Vector2 position = camera.ScreenToWorldPoint(screenPoint);
            var direction = Vector2.zero;

            var hits = Physics2D.RaycastNonAlloc
            (
                position,
                direction,
                _cache,
                1000f,
                1 << layer
            );
            for (var i = 0; i < hits; i++)
            {
                var hit = _cache[i];

                if (hit.collider == null) continue;
                if (hit.transform.GetComponent<T>() == null) continue;

                Debug.Log($"collider {hit.transform.gameObject.name} exist, component {typeof(T)} exist");

                return hit.transform;
            }

            return null;
        }
    }
}
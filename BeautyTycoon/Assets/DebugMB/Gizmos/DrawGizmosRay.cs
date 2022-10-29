using UnityEngine;

namespace BT.DebugMB.Gizmos
{
    public class DrawGizmosRay : DrawGizmosMonoBehaviour
    {
#if UNITY_EDITOR
        private Vector2 _position;
        private Vector2 _direction;

        public void SetPointAndDirection(Vector2 position, Vector2 direction)
        {
            _position = position;
            _direction = direction;

            Destroy(this, 5f);
        }

        protected override void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = Color.green;
            UnityEngine.Gizmos.DrawRay(_position, _direction);
        }
#endif
    }
}
using UnityEngine;

namespace BT.DebugMB.Gizmos
{
    public abstract class DrawGizmosMonoBehaviour : MonoBehaviour
    {
#if UNITY_EDITOR
        protected abstract void OnDrawGizmos();
#endif
    }
}
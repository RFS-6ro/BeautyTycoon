using System;

using BT.Core.Utils;

using UnityEngine;
using UnityEngine.EventSystems;

namespace BT.Meta.Common.UI.Input
{
    public class PanelTouchInputListener : MonoBehaviour, IDragHandler,
        IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] private float _clickInterval = 0.5f;
        private float _lastClickTime;

        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent.SafeInvoke(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent.SafeInvoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent.SafeInvoke(eventData.position);
            if (Time.time - _lastClickTime <= _clickInterval) OnDoubleClickEvent.SafeInvoke(eventData.position);

            _lastClickTime = Time.time;
        }

        public event Action<Vector2> OnClickEvent;
        public event Action<Vector2> OnDoubleClickEvent;
        public event Action<Vector2> OnDragEvent;

        public event Action OnEndDragEvent;
    }
}
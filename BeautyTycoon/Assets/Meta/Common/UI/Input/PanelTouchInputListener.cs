using System;
using Core.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Meta.Common.UI.Input
{
    public class PanelTouchInputListener : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private float _lastClickTime = 0f;
        
        [SerializeField] private float _clickInterval = 0.5f;
        
        public event Action<Vector2> OnClickEvent;
        public event Action<Vector2> OnDoubleClickEvent;
        public event Action<Vector2> OnDragEvent;
        
        public event Action OnEndDragEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent.SafeInvoke(eventData.position);
            if (Time.time - _lastClickTime <= _clickInterval)
            {
                OnDoubleClickEvent.SafeInvoke(eventData.position);
            }

            _lastClickTime = Time.time;
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent.SafeInvoke(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent.SafeInvoke();
        }
    }
}

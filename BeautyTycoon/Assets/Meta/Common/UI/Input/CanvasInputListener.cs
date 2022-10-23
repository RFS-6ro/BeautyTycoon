using System;
using Core.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Meta.Common.UI.Input
{
    public class CanvasInputListener : MonoBehaviour, IPointerClickHandler
    {
        private float _lastClickTime = 0f;
        
        [SerializeField] private float _clickInterval = 0.5f;
        
        public event Action<Vector2> OnClick;
        public event Action<Vector2> OnDoubleClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("One Tap");
            //OnClick.SafeInvoke(eventData.position);
            if (Time.time - _lastClickTime <= _clickInterval)
            {
                Debug.Log("Double Tap");
                //OnDoubleClick.SafeInvoke(eventData.position);
            }

            _lastClickTime = Time.time;
        }
    }
}

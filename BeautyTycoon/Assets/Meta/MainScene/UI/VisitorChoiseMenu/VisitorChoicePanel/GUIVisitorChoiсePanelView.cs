using System;

using BT.Core.UI.View;
using BT.Core.Utils;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;

using UnityEngine;

namespace BT.Meta.MainScene.UI.VisitorChoseMenu.VisitorChoicePanel
{
    public class GUIVisitorChoiсePanelView : UIView
    {
        [SerializeField] private GUITextWithImageView _choice;
        [SerializeField] private RectTransform _pivot;
        [SerializeField] private PanelTouchInputListener _swipeListener;

        [SerializeField] private float _maxAngleAbs = 25f;
        [SerializeField] private float _angleRotationDelta = 0.5f;
        [SerializeField] private float _successChoiceEpsilon = 0.8f;

        private float _currentAngle;

        private Action _onChoose;
        private Action<GUIVisitorChoiсePanelView> _onDecline;
        private RectTransform _rectTransform;

        private void OnEnable()
        {
            if (_swipeListener != null)
            {
                _swipeListener.OnDragEvent += HandleSwipe;
                _swipeListener.OnEndDragEvent += HandleSwipeRelease;
            }
        }

        private void OnDisable()
        {
            if (_swipeListener != null)
            {
                _swipeListener.OnDragEvent -= HandleSwipe;
                _swipeListener.OnEndDragEvent -= HandleSwipeRelease;
            }
        }

        protected override void OnAwake()
        {
            _rectTransform = GetComponent<RectTransform>();
#if DEBUG
            Debug.Assert(_choice != null);
            Debug.Assert(_pivot != null);
            Debug.Assert(_swipeListener != null);
#endif
        }

        public void ShowChoiceWithAction
        (
            string                            choice, Action onChoose,
            Action<GUIVisitorChoiсePanelView> onDecline
        )
        {
            _choice.ShowText(choice);
            _onChoose = onChoose;
            _onDecline = onDecline;
        }

        private void HandleSwipe(Vector2 delta)
        {
            var deltaRotation =
                delta.x > 0 ? -_angleRotationDelta : _angleRotationDelta;
            var nextRotation = _currentAngle + deltaRotation;
            if (Mathf.Abs(nextRotation) < _maxAngleAbs)
            {
                _rectTransform.RotateAround
                    (_pivot.position, Vector3.forward, deltaRotation);
                _currentAngle += deltaRotation;
            }
        }

        private void HandleSwipeRelease()
        {
            _rectTransform.RotateAround
                (_pivot.position, Vector3.forward, -_currentAngle);

            if (Mathf.Abs(_currentAngle) > _maxAngleAbs * _successChoiceEpsilon)
            {
                if (_currentAngle < 0)
                    _onChoose.SafeInvoke();
                else
                    _onDecline.SafeInvoke(this);
            }

            _currentAngle = 0;
        }
    }
}
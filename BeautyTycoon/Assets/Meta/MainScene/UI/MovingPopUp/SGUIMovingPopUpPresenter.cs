using BT.Meta.Common;
using BT.Meta.Common.Assets.Characters.Visitor_default;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.UI.MovingPopUp
{
    public class SGUIMovingPopUpPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private Camera _camera;

        private EcsFilter<CChoiceVariant, CUnit> _filter;
        private GUIMovingPopUpView _movingPopUpView;

        private Transform _popUpTransform;
        private RectTransform _rectangle;

        public void Init()
        {
            _popUpTransform = _movingPopUpView.transform;
        }

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                _movingPopUpView.Activate();
                var choiceVariant = _filter.Get1(entityId);
                var unit = _filter.Get2(entityId);

                var target = unit.Transform;

                Vector2 screenPointForNotification = _camera.WorldToScreenPoint
                    (target.position);
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                (
                    _rectangle,
                    screenPointForNotification,
                    _camera,
                    out var localCanvasPosition
                );

                _popUpTransform.position = localCanvasPosition;

                return;
            }

            _movingPopUpView.Deactivate();
        }
    }
}
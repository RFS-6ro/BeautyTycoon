using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.Visitor_default;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.MainScene.UI.MovingPopUp
{
    public class SGUIMovingPopUpPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private RectTransform _rectangle;
        private Camera _camera;
        private GUIMovingPopUpView _movingPopUpView;

        private Transform _popUpTransform;

        private EcsFilter<CChoiceVariant, CUnit> _filter;

        public void Init()
        {
            _popUpTransform = _movingPopUpView.transform;
        }
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                _movingPopUpView.Activate();
                CChoiceVariant choiceVariant = _filter.Get1(entityId);
                CUnit unit = _filter.Get2(entityId);

                Transform target = unit.Transform;
                
                Vector2 screenPointForNotification = _camera.WorldToScreenPoint(target.position);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _rectangle,
                    screenPointForNotification,
                    _camera,
                    out Vector2 localCanvasPosition);

                _popUpTransform.position = localCanvasPosition;
                
                return;
            }
            
            _movingPopUpView.Deactivate();
        }
    }
}

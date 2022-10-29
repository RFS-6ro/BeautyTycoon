using BT.Meta.Common.Assets.Characters.MainCharacter;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.UI.Input
{
    public class STouchInputSender : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsFilter<CTouchInputListener> _filter;
        private PanelTouchInputListener _panelTouchInputListener;

        public void Destroy()
        {
            if (!_panelTouchInputListener) return;

            _panelTouchInputListener.OnClickEvent -= HandleSimpleClickEvent;
            _panelTouchInputListener.OnDoubleClickEvent -=
                HandleDoubleClickEvent;
        }

        public void Init()
        {
            if (_panelTouchInputListener == null) return;

            _panelTouchInputListener.OnClickEvent += HandleSimpleClickEvent;
            _panelTouchInputListener.OnDoubleClickEvent += HandleDoubleClickEvent;
        }

        private void HandleSimpleClickEvent(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref var tap = ref _filter.GetEntity(entityId)
                    .Get<CTap>();
                tap.Position = position;
            }
        }

        private void HandleDoubleClickEvent(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref var doubleTap = ref _filter.GetEntity(entityId)
                    .Get<CDoubleTap>();
                doubleTap.Position = position;
            }
        }
    }
}
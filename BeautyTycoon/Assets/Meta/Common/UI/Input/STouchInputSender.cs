using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MainCharacter;
using UnityEngine;

namespace Meta.Common.UI.Input
{
    public class STouchInputSender : IEcsInitSystem, IEcsDestroySystem
    {
        private PanelTouchInputListener _panelTouchInputListener;
        
        private EcsFilter<CTouchInputListener> _filter;

        public void Init()
        {
            if (_panelTouchInputListener == null) { return; }
            
            _panelTouchInputListener.OnClickEvent += HandleSimpleClickEvent;
            _panelTouchInputListener.OnDoubleClickEvent += HandleDoubleClickEvent;
        }

        private void HandleSimpleClickEvent(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref CTap tap = ref _filter.GetEntity(entityId).Get<CTap>();
                tap.Position = position;
            }
        }

        private void HandleDoubleClickEvent(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref CDoubleTap doubleTap = ref _filter.GetEntity(entityId).Get<CDoubleTap>();
                doubleTap.Position = position;
            }
        }

        public void Destroy()
        {
            if (!_panelTouchInputListener) { return; }
            
            _panelTouchInputListener.OnClickEvent -= HandleSimpleClickEvent;
            _panelTouchInputListener.OnDoubleClickEvent -= HandleDoubleClickEvent;
        }
    }
}

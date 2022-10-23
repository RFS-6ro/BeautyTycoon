using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MainCharacter;
using UnityEngine;

namespace Meta.Common.UI.Input
{
    public class STouchInputSender : IEcsInitSystem, IEcsDestroySystem
    {
        private CanvasInputListener _canvasInputListener;
        
        private EcsFilter<CTouchInputListener> _filter;

        public void Init()
        {
            if (_canvasInputListener == null) { return; }
            
            _canvasInputListener.OnClick += HandleSimpleClick;
            _canvasInputListener.OnDoubleClick += HandleDoubleClick;
        }

        private void HandleSimpleClick(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref CTap tap = ref _filter.GetEntity(entityId).Get<CTap>();
                tap.Position = position;
            }
        }

        private void HandleDoubleClick(Vector2 position)
        {
            foreach (var entityId in _filter)
            {
                ref CDoubleTap doubleTap = ref _filter.GetEntity(entityId).Get<CDoubleTap>();
                doubleTap.Position = position;
            }
        }

        public void Destroy()
        {
            if (!_canvasInputListener) { return; }
            
            _canvasInputListener.OnClick -= HandleSimpleClick;
            _canvasInputListener.OnDoubleClick -= HandleDoubleClick;
        }
    }
}

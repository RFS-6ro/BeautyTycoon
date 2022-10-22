using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Core.CompositeRoot
{
    public abstract class EcsStartupBase : MonoBehaviour
    {
        protected EcsWorld _world;

        protected EcsSystems _updateSystems;
        protected EcsSystems _fixedUpdateSystems;
        protected EcsSystems _lateUpdateSystems;

        private void Awake()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);
            
            OnAwake();
            AddLogicParts();
            
            _updateSystems?.Init();
            _fixedUpdateSystems?.Init();
            _lateUpdateSystems?.Init();
        }

        protected virtual void OnAwake() { }
        
        protected virtual void AddLogicParts() { }

        private void Update()
        {
            _updateSystems?.Run();
            OnUpdate();
        }
        
        protected virtual void OnUpdate() { }
        
        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
            OnFixedUpdate();
        }
        
        protected virtual void OnFixedUpdate() { }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
            OnLateUpdate();
        }
        
        protected virtual void OnLateUpdate() { }
    }
}
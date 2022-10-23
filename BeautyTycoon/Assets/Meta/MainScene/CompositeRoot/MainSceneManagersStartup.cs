using Core.CompositeRoot;
using Leopotam.Ecs;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneManagersStartup : 
        IUpdateLogicPartStartup<MainSceneManagersStartup>, 
        IFixedUpdateLogicPartStartup<MainSceneManagersStartup>, 
        ILateUpdateLogicPartStartup<MainSceneManagersStartup>
    {
        public readonly Camera Camera;
        
        public MainSceneManagersStartup()
        {
            Camera = Camera.main;
        }

        public MainSceneManagersStartup AddUpdateSystems(EcsSystems systems)
        {
            return this;
        }

        public MainSceneManagersStartup AddFixedUpdateSystems(EcsSystems systems)
        {
            return this;
        }

        public MainSceneManagersStartup AddLateUpdateSystems(EcsSystems systems)
        {
            //TODO: Add Camera Manager
            return this;
        }
    }
}

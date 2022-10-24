using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.UI.Input;
using Meta.MainScene.CameraLogic;
using Meta.MainScene.SceneReloader;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneManagersStartup : 
        IUpdateLogicPartStartup<MainSceneManagersStartup>, 
        IFixedUpdateLogicPartStartup<MainSceneManagersStartup>, 
        ILateUpdateLogicPartStartup<MainSceneManagersStartup>
    {
        private readonly PanelTouchInputListener _panelTouchInputListener;
        private readonly Camera _camera;
        
        public MainSceneManagersStartup(PanelTouchInputListener panelTouchInputListener, Camera camera)
        {
            _panelTouchInputListener = panelTouchInputListener;
            _camera = camera;
        }

        public MainSceneManagersStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SSceneReloader())
                .OneFrame<CReloadSceneRequest>();
            return this;
        }

        public MainSceneManagersStartup AddFixedUpdateSystems(EcsSystems systems)
        {
            return this;
        }

        public MainSceneManagersStartup AddLateUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SCameraMovement())
                .Inject(_camera)
                .Inject(_panelTouchInputListener);
            return this;
        }
    }
}

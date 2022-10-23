using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.InputHandling;
using Meta.Common.UI.Input;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneInputHandlingStartup : 
        IUpdateLogicPartStartup<MainSceneInputHandlingStartup>
    {
        private readonly PanelTouchInputListener _panelTouchInputListener;

        public MainSceneInputHandlingStartup(PanelTouchInputListener panelTouchInputListener)
        {
            _panelTouchInputListener = panelTouchInputListener;
        }
        
        public MainSceneInputHandlingStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new STouchInputSender())
                .Add(new SKeyboardInputSender())
                .OneFrame<CTap>()
                .OneFrame<CDoubleTap>()
                .Inject(_panelTouchInputListener);
            return this;
        }
    }
}

using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.InputHandling;
using Meta.Common.UI.Input;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneInputHandlingStartup : 
        IUpdateLogicPartStartup<MainSceneInputHandlingStartup>
    {
        private readonly CanvasInputListener _canvasInputListener;

        public MainSceneInputHandlingStartup(CanvasInputListener canvasInputListener)
        {
            _canvasInputListener = canvasInputListener;
        }
        
        public MainSceneInputHandlingStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new STouchInputSender())
                .Add(new SKeyboardInputSender())
                .OneFrame<CTap>()
                .OneFrame<CDoubleTap>()
                .Inject(_canvasInputListener);
            return this;
        }
    }
}

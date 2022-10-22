using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.InputHandling;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneInputHandlingStartup : 
        IUpdateLogicPartStartup<MainSceneInputHandlingStartup>
    {
        public MainSceneInputHandlingStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SKeyboardInputSender());
            return this;
        }
    }
}
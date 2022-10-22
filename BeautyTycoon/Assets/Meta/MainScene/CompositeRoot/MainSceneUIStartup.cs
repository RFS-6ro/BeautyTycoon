using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.UI.Input;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        public MainSceneUIStartup()
        {
            CanvasInputListener = null;
        }
        
        public CanvasInputListener CanvasInputListener { get; private set; }
        
        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}

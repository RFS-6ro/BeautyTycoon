using Core.CompositeRoot;
using Leopotam.Ecs;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        public MainSceneUIStartup()
        {
            
        }
        
        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}

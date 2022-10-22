using Core.CompositeRoot;
using Leopotam.Ecs;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUnitsStartup : IUpdateLogicPartStartup<MainSceneUnitsStartup>
    {
        public MainSceneUnitsStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}

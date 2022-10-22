using Core.CompositeRoot;
using Leopotam.Ecs;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneWorkingToolsStartup : IUpdateLogicPartStartup<MainSceneWorkingToolsStartup>
    {
        public MainSceneWorkingToolsStartup AddUpdateSystems(EcsSystems systems)
        {

            return this;
        }
    }
}
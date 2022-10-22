using Core.CompositeRoot;
using Leopotam.Ecs;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEnvironmentStartup : IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public MainSceneEnvironmentStartup AddUpdateSystems(EcsSystems systems)
        {
            new MainSceneWorkingToolsStartup()
                .AddUpdateSystems(systems);

            return this;
        }
    }
}

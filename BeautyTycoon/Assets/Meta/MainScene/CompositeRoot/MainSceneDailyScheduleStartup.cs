using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Environment.DailySchedule;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneDailyScheduleStartup : IUpdateLogicPartStartup<MainSceneDailyScheduleStartup>
    {
        public MainSceneDailyScheduleStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SWorldTimeChange());
            return this;
        }
    }
}

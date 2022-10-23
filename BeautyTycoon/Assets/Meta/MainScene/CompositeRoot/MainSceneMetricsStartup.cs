using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Environment.Balance;
using Meta.Common.Environment.DailySchedule;
using Meta.Common.Environment.Reputation;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneMetricsStartup : IUpdateLogicPartStartup<MainSceneMetricsStartup>
    {
        public MainSceneMetricsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SWorldTimeChange())
                .OneFrame<CReputationChange>()
                .OneFrame<CBalanceChange>();
            return this;
        }
    }
}

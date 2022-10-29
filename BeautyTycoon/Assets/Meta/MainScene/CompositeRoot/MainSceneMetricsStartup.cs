using BT.Core.CompositeRoot;
using BT.Meta.Common.Environment.Balance;
using BT.Meta.Common.Environment.DailySchedule;
using BT.Meta.Common.Environment.Reputation;

using Leopotam.Ecs;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneMetricsStartup : IUpdateLogicPartStartup<
            MainSceneMetricsStartup>
    {
        public MainSceneMetricsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SWorldTimeChange())
                .Add(new SBalanceHandler())
                .Add(new SReputationHandler())
                .OneFrame<CReputationChange>()
                .OneFrame<CBalanceChange>();
            return this;
        }
    }
}
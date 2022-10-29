using BT.Meta.Common.Environment.Reputation.Utils;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Environment.Reputation
{
    public class SReputationHandler : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CReputationChange> _balanceChangeFilter;

        private EcsEntity _balanceStorage;
        private MetricsConfiguration _metrics;
        private EcsWorld _world;

        public void Init()
        {
            _balanceStorage = _world.NewEntity();
            ref var balance = ref _balanceStorage.Get<CReputation>();
            balance.Percentage = ReputationUtils.CalculatePercentage();
        }

        public void Run()
        {
            foreach (var entityId in _balanceChangeFilter)
            {
                var entity = _balanceChangeFilter.GetEntity(entityId);
                var balanceChange = _balanceChangeFilter.Get1(entityId);
                AddVisitor(balanceChange.Delta);

                ref var balance = ref _balanceStorage.Get<CReputation>();
                balance.Percentage = ReputationUtils.CalculatePercentage();

                entity.Del<CReputationChange>();
                break;
            }
        }

        private void AddVisitor(int delta)
        {
            var totalVisitors = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_VISITORS, 0);
            PlayerPrefs.SetInt
                (MetricsConfiguration.TOTAL_VISITORS, ++totalVisitors);

            if (delta > 0)
            {
                var successfullyProcessedVisitors = PlayerPrefs.GetInt
                    (MetricsConfiguration.SUCCESS_PROCESSED, 0);
                PlayerPrefs.SetInt
                (
                    MetricsConfiguration.SUCCESS_PROCESSED,
                    ++successfullyProcessedVisitors
                );
            }
        }
    }
}
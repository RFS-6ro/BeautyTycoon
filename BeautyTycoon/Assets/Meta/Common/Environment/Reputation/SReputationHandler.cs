using Leopotam.Ecs;
using Meta.Common.Environment.Reputation.Utils;
using UnityEngine;

namespace Meta.Common.Environment.Reputation
{
    public class SReputationHandler : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private MetricsConfiguration _metrics;
        
        private EcsEntity _balanceStorage;
        
        private EcsFilter<CReputationChange> _balanceChangeFilter;

        public void Init()
        {
            _balanceStorage = _world.NewEntity();
            ref CReputation balance = ref _balanceStorage.Get<CReputation>();
            balance.Percentage = ReputationUtils.CalculatePercentage();
        }

        public void Run()
        {
            foreach (var entityId in _balanceChangeFilter)
            {
                EcsEntity entity = _balanceChangeFilter.GetEntity(entityId);
                CReputationChange balanceChange = _balanceChangeFilter.Get1(entityId);
                AddVisitor(balanceChange.Delta);
                
                ref CReputation balance = ref _balanceStorage.Get<CReputation>();
                balance.Percentage = ReputationUtils.CalculatePercentage();
                
                entity.Del<CReputationChange>();
                break;
            }
        }

        private void AddVisitor(int delta)
        {
            int totalVisitors = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_VISITORS, 0);
            PlayerPrefs.SetInt(MetricsConfiguration.TOTAL_VISITORS, ++totalVisitors);
            
            if (delta > 0)
            {
                int successfullyProcessedVisitors = PlayerPrefs.GetInt(MetricsConfiguration.SUCCESS_PROCESSED, 0);
                PlayerPrefs.SetInt(MetricsConfiguration.SUCCESS_PROCESSED, ++successfullyProcessedVisitors);
            }
        }
    }
}
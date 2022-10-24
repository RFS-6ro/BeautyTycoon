using Leopotam.Ecs;
using UnityEngine;

namespace Meta.Common.Environment.Balance
{
    public class SBalanceHandler : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private MetricsConfiguration _metrics;
        
        private EcsEntity _balanceStorage;
        
        private EcsFilter<CBalanceChange> _balanceChangeFilter;

        public void Init()
        {
            _balanceStorage = _world.NewEntity();
            ref CBalance balance = ref _balanceStorage.Get<CBalance>();
            balance.Amount = GetActualBalance();
        }

        public void Run()
        {
            foreach (var entityId in _balanceChangeFilter)
            {
                EcsEntity entity = _balanceChangeFilter.GetEntity(entityId);
                CBalanceChange balanceChange = _balanceChangeFilter.Get1(entityId);
                UpdateBalance(balanceChange.Delta);
                
                ref CBalance balance = ref _balanceStorage.Get<CBalance>();
                balance.Amount = GetActualBalance();
                
                entity.Del<CBalanceChange>();
                break;
            }
        }

        private int GetActualBalance()
        {
            return PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_BALANCE, _metrics.InitialBalance);
        }

        private void UpdateBalance(int delta)
        {
            int totalBalance = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_BALANCE, _metrics.InitialBalance);
            PlayerPrefs.SetInt(MetricsConfiguration.TOTAL_VISITORS, totalBalance + delta);
        }
    }
}
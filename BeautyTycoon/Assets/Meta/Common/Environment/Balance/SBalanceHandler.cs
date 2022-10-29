using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Environment.Balance
{
    public class SBalanceHandler : IEcsInitSystem, IEcsRunSystem,
        IEcsDestroySystem
    {
        private EcsFilter<CBalanceChange> _balanceChangeFilter;

        private EcsEntity _balanceStorage;
        private MetricsConfiguration _metrics;
        private EcsWorld _world;

        public void Destroy()
        {
            UpdateBalance(-_metrics.DailyRent);
            PlayerPrefs.SetInt
                (MetricsConfiguration.TOTAL_BALANCE_PREV, GetActualBalance());
            PlayerPrefs.Save();
        }

        public void Init()
        {
            _balanceStorage = _world.NewEntity();
            ref var balance = ref _balanceStorage.Get<CBalance>();
            balance.Amount = GetActualBalance();
        }

        public void Run()
        {
            foreach (var entityId in _balanceChangeFilter)
            {
                var entity = _balanceChangeFilter.GetEntity(entityId);
                var balanceChange = _balanceChangeFilter.Get1(entityId);
                UpdateBalance(balanceChange.Delta);

                ref var balance = ref _balanceStorage.Get<CBalance>();
                balance.Amount = GetActualBalance();

                entity.Del<CBalanceChange>();
                break;
            }
        }

        private int GetActualBalance()
        {
            var balance = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_BALANCE, _metrics.InitialBalance);
            PlayerPrefs.Save();
            return balance;
        }

        private void UpdateBalance(int delta)
        {
            var totalBalance = GetActualBalance();
            PlayerPrefs.SetInt
                (MetricsConfiguration.TOTAL_BALANCE, totalBalance + delta);
            PlayerPrefs.Save();
        }
    }
}
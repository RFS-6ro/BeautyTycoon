using Leopotam.Ecs;

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
            balance.Amount = _metrics.InitialBalance;
        }

        public void Run()
        {
            foreach (var entityId in _balanceChangeFilter)
            {
                EcsEntity entity = _balanceChangeFilter.GetEntity(entityId);
                
                entity.Del<CBalanceChange>();
                break;
            }
        }
    }
}
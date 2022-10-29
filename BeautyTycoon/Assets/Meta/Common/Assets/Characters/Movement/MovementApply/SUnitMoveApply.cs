using Leopotam.Ecs;

namespace BT.Meta.Common.Assets.Characters.MovementApply
{
    public class SUnitMoveApply : IEcsRunSystem
    {
        private EcsFilter<CUnit, CMovementDelta> _filter;

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                ref var unit = ref _filter.Get1(entityId);
                ref var movementDeltaRef = ref _filter.Get2(entityId);

                unit.Transform.position += movementDeltaRef.Delta;
            }
        }
    }
}
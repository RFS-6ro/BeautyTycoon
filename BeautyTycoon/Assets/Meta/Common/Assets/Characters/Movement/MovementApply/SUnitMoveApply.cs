using BT.Meta.Common.Characters;
using Leopotam.Ecs;

namespace Meta.Common.Assets.Characters.MovementApply
{
    public class SUnitMoveApply : IEcsRunSystem
    {
        private EcsFilter<CUnit, CMovementDelta> _filter;
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                ref CUnit unit = ref _filter.Get1(entityId);
                ref CMovementDelta movementDeltaRef = ref _filter.Get2(entityId);

                unit.Transform.position += movementDeltaRef.Delta;
            }
        }
    }
}

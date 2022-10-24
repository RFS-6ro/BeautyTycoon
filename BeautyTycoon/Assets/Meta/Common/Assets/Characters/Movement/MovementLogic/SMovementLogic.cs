using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic
{
    public class SMovementLogic : IEcsInitSystem, IEcsRunSystem
    {
        private ICellMovementCalculator _cellMovementCalculator;
        
        private EcsFilter<CUnit, CTargetCell> _filter;

        public void Init()
        {
            _cellMovementCalculator.Init();
        }
        
        public void Run()
        {
            if (_cellMovementCalculator == null) { return; }

            foreach (var entityId in _filter)
            {
                ref var entity = ref _filter.GetEntity(entityId);
                
                ref CUnit unit = ref _filter.Get1(entityId);
                ref CTargetCell targetCellData = ref _filter.Get2(entityId);

                if (!unit.Transform.position.TryGetCellByWorldPosition(out Vector3Int currentCell))
                {
                    return;
                }
                
                ref var movementDelta = ref _filter.GetEntity(entityId).Get<CMovementDelta>();
                movementDelta.Delta = _cellMovementCalculator.GetNextFrameDelta(entity, currentCell, targetCellData.Cell);
            }
        }
    }
}

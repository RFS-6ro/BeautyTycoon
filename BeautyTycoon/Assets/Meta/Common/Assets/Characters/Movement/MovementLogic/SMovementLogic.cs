using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic
{
    public class SMovementLogic : IEcsRunSystem
    {
        private ICellMovementCalculator _cellMovementCalculator;
        
        private EcsFilter<CUnit, CTargetCell> _filter;
        
        public void Run()
        {
            if (!_cellMovementCalculator.IsAssigned) { return; }
            
            foreach (var entityId in _filter)
            {
                ref var entity = ref _filter.GetEntity(entityId);
                
                ref CUnit unit = ref _filter.Get1(entityId);
                ref CTargetCell targetCellData = ref _filter.Get2(entityId);

                Vector2Int currentCell = unit.Transform.position.GetCellByPosition();

                Vector3 nextFrameDelta = _cellMovementCalculator.GetNextFrameDelta(entity, currentCell, targetCellData.Cell);
                
                ref var movementDelta = ref _filter.GetEntity(entityId).Get<CMovementDelta>();
                movementDelta.Delta = nextFrameDelta;
            }
        }
    }
}
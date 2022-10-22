using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.Common.Assets.Characters.Movement
{
    public class SConvertTouchToCellMovement : IEcsRunSystem
    {
        private EcsFilter<CUnit, CDoubleTap> _filter;
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                CDoubleTap doubleTap = _filter.Get2(entityId);
                
                if (doubleTap.Position.TryGetCellByScreenPosition(out Vector2Int cell))
                {
                    ref CTargetCell targetCell = ref _filter.GetEntity(entityId).Get<CTargetCell>();
                    targetCell.Cell = cell;
                }
            }
        }
    }
}

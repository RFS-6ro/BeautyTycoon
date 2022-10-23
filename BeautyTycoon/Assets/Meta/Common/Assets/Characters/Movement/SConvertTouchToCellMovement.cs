using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using Meta.Common.Environment.World;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.Common.Assets.Characters.Movement
{
    public class SConvertTouchToCellMovement : IEcsRunSystem
    {
        private Camera _camera;
        
        private EcsFilter<CUnit, CDoubleTap> _filter;
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                CDoubleTap doubleTap = _filter.Get2(entityId);
                
                if (!Physics.Raycast(_camera.ScreenPointToRay(doubleTap.Position), out RaycastHit hit)) { continue; }

                if (hit.transform.GetComponent<WorldTileTag>() == null) { continue; }
                
                if (hit.transform.position.TryGetCellByWorldPosition(out Vector3Int cell))
                {
                    ref CTargetCell targetCell = ref _filter.GetEntity(entityId).Get<CTargetCell>();
                    targetCell.Cell = cell;
                }
            }
        }
    }
}

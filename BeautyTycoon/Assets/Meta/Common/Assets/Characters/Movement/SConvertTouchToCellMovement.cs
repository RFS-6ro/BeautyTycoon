using BT.Core.Utils;
using BT.Meta.Common.Assets.Characters.MovementLogic;
using BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using BT.Meta.Common.Environment.World;
using BT.Meta.Common.UI.Input;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.Movement
{
    public class SConvertTouchToCellMovement : IEcsRunSystem
    {
        private Camera _camera;

        private EcsFilter<CUnit, CDoubleTap> _filter;

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                Debug.Log("Try double tap register");
                var doubleTap = _filter.Get2(entityId);

                var tile = _camera.Raycast2DScreenSpace<WorldTileTag>
                    (doubleTap.Position, 6);

                if (tile == null) continue;

                if (tile.position.TryGetCellByWorldPosition(out var cell))
                {
                    ref var targetCell = ref _filter.GetEntity(entityId)
                        .Get<CTargetCell>();
                    targetCell.Cell = cell;
                }
            }
        }
    }
}
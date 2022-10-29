using BT.Core.Utils;
using BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using BT.Meta.Common.Environment.World;
using BT.Meta.Common.UI.Input;
using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.WorkingTools.Selection
{
    public class SWorkingToolMove : IEcsRunSystem
    {
        private Camera _camera;
        private WorkingToolPositioningData _data;

        private EcsFilter<CUnit, CWorkingTool, CWorkingToolSelection, CTap> _filter;
        private Grid _grid;
        private MapMask _mask;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                var tap = _filter.Get4(entityId);

                var tile = _camera.Raycast2DScreenSpace<WorldTileTag>
                    (tap.Position, 6);

                if (tile == null) continue;

                if (tile.position.TryGetCellByWorldPosition(out var cell)
                    && _mask.Map[cell.x, cell.y] != MapMask.NON_WALKABLE)
                {
                    var unit = _filter.Get1(entityId);
                    var nextPosition = _grid.GetCellCenterWorld(cell);

                    unit.Transform.position = nextPosition;
                    _mask.Map[cell.x, cell.y] = MapMask.NON_WALKABLE;

                    ref var tool = ref _filter.Get2(entityId);
                    var toolData = _data.GetWorkingToolData(tool.Class);

                    toolData.Positions.Remove(tool.Position);
                    _mask.Map[tool.Position.x, tool.Position.y] = MapMask.WALKABLE;

                    toolData.Positions.Add(cell);
                    tool.Position = cell;
                }

                _filter.GetEntity(entityId)
                    .Del<CWorkingToolSelection>();
            }
        }
    }
}
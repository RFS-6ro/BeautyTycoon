using BT.Meta.Common.Environment.World;
using BT.Meta.Common.World.Creation;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public static class CellUtils
    {
        private static Grid _grid;
        private static MapMask _mask;

        public static void Initialize(Grid grid, MapMask mask)
        {
            _grid = grid;
            _mask = mask;
        }

        public static bool TryGetCellByWorldPosition
            (this Vector3 position, out Vector3Int cell)
        {
            cell = _grid.WorldToCell(position);
            return _mask.Map.Inside(cell.x, cell.y);
        }
    }
}
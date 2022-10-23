using System;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public static class CellUtils
    {
        private static UnityEngine.Grid _grid;
        private static MapMask _mask;
        public static void Initialize(UnityEngine.Grid grid, MapMask mask)
        {
            _grid = grid;
            _mask = mask;
        }
        
        public static bool TryGetCellByWorldPosition(this Vector3 position, out Vector3Int cell)
        {
            throw new NotImplementedException();
        }
        
        public static Vector3Int GetClosestEmptyCell(this Vector3 position)
        {
            throw new NotImplementedException();
        }
    }
}
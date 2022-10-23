using Leopotam.Ecs;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public class CellMovementCalculatorMock : ICellMovementCalculator
    {
        private readonly UnityEngine.Grid _grid;
        private readonly MapMask _mask;

        public CellMovementCalculatorMock(UnityEngine.Grid grid, MapMask mask)
        {
            _grid = grid;
            _mask = mask;
        }

        public Vector3 GetNextFrameDelta(EcsEntity ecsEntity, Vector3Int currentCell, Vector3Int targetCell)
        {
            if (currentCell == targetCell)
            {
                return targetCell;
            }

            return targetCell;
        }
    }
}
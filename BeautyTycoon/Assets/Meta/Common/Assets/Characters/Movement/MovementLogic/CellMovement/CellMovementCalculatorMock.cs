using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public class CellMovementCalculatorMock : ICellMovementCalculator
    {
        private readonly Grid _grid;
        private readonly MapMask _mask;

        public CellMovementCalculatorMock(Grid grid, MapMask mask)
        {
            _grid = grid;
            _mask = mask;
        }

        public void Init() { }

        public Vector3 GetNextFrameDelta
            (EcsEntity ecsEntity, Vector3Int currentCell, Vector3Int targetCell)
        {
            if (currentCell == targetCell) return targetCell;

            return targetCell;
        }
    }
}
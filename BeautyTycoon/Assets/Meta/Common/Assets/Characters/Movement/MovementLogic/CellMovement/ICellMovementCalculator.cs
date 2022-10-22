using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public interface ICellMovementCalculator
    {
        bool IsAssigned { get; }
        
        Vector3 GetNextFrameDelta(Vector2Int currentCell, Vector2Int cell);
    }
}
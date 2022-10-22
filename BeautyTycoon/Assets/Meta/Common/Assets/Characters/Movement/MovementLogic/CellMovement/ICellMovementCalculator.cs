using Leopotam.Ecs;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public interface ICellMovementCalculator
    {
        bool IsAssigned { get; }
        
        Vector3 GetNextFrameDelta(EcsEntity ecsEntity, Vector2Int currentCell, Vector2Int cell);
    }
}
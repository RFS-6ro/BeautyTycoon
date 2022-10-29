using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public interface ICellMovementCalculator
    {
        void Init();

        Vector3 GetNextFrameDelta
        (
            EcsEntity ecsEntity, Vector3Int currentCell, Vector3Int targetCell
        );
    }
}
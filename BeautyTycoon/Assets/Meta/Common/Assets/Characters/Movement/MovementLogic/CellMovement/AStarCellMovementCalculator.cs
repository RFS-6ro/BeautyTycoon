using System.Collections.Generic;
using System.Linq;
using AI.A_Star;
using Leopotam.Ecs;
using Meta.Common.Environment.World;
using Meta.Common.World.Creation;
using UnityEngine;
using Vector2Int = AI.A_Star.Vector2Int;

namespace Meta.Common.Assets.Characters.MovementLogic.CellMovement
{
    public class AStarCellMovementCalculator : ICellMovementCalculator
    {
        private readonly Grid _grid;
        private readonly MapMask _mask;

        private readonly Path _path;
        private readonly List<Vector2Int> _obstacles;

        public AStarCellMovementCalculator(Grid grid, MapMask mask)
        {
            _grid = grid;
            _mask = mask;

            _path = new Path();
            
            _obstacles = new List<Vector2Int>();
            _mask.Map.ForEachCell((x, y) =>
            {
                if (_mask.Map[x, y] == MapMask.NON_WALKABLE)
                {
                    _obstacles.Add(new Vector2Int(x, y));
                }
            });
        }
        
        public Vector3 GetNextFrameDelta(EcsEntity ecsEntity, Vector3Int currentCell, Vector3Int targetCell)
        {
            _path.Calculate(currentCell, targetCell, _obstacles, out IReadOnlyCollection<Vector2Int> path);
            return _grid.GetCellCenterWorld(path.ElementAt(0));
        }
    }
}
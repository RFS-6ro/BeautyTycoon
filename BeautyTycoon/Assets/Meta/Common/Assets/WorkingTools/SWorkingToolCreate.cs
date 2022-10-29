using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.WorkingTools
{
    public abstract class SWorkingToolCreate : IEcsInitSystem
    {
        protected WorkingToolPositioningData.WorkingToolData _data;
        protected Grid _grid;
        protected WorkingToolPositioningData _positioningData;
        protected EcsWorld _world;

        protected abstract WorkingToolsClassification Class { get; }

        public void Init()
        {
            if (_positioningData == null)
            {
#if DEBUG
                Debug.LogError($"WorkingToolPositioningData is null for {GetType()}");
#endif
                return;
            }

            _data = _positioningData.GetWorkingToolData(Class);
            if (_data == null)
            {
#if DEBUG
                Debug.LogError($"WorkingToolData is null for {GetType()}");
#endif
                return;
            }

            foreach (var position in _data.Positions) CreateWorkingTool(_grid.GetCellCenterWorld(position), position);
        }

        protected abstract void CreateWorkingTool(Vector3 position, Vector3Int cell);
    }
}
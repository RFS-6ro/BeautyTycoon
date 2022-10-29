using BT.Core.Utils;
using BT.Meta.Common.UI.Input;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.WorkingTools.Selection
{
    public class SWorkingToolSelection : IEcsRunSystem
    {
        private Camera _camera;

        private EcsFilter<CUnit, CWorkingTool, CTap> _filter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                var unit = _filter.Get1(entityId);
                var tap = _filter.Get3(entityId);

                var workingTool = _camera.Raycast2DScreenSpace<WorkingToolTag>
                    (tap.Position, 6);

                if (workingTool == null || workingTool != unit.Transform) continue;

                var entity = _filter.GetEntity(entityId);
                if (entity.Has<CWorkingToolSelection>())
                    entity.Del<CWorkingToolSelection>();
                else
                    entity.Get<CWorkingToolSelection>();

                entity.Del<CTap>();
            }
        }
    }
}
using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.WorkingTools.NailBar
{
    public class SNailBarCreate : SWorkingToolCreate
    {
        private MapMask _mask;

        protected override WorkingToolsClassification Class => WorkingToolsClassification.NailBar;

        protected override void CreateWorkingTool(Vector3 position, Vector3Int cell)
        {
            var nailBar = Object.Instantiate(_data.Prefab)
                .transform;
            nailBar.position = position;

            var nailBarEntity = _world.NewEntity();

            ref var unit = ref nailBarEntity.Get<CUnit>();
            unit.Transform = nailBar;

            ref var tool = ref nailBarEntity.Get<CWorkingTool>();
            tool.Class = Class;
            tool.Position = cell;
            _mask.Map[cell.x, cell.y] = MapMask.NON_WALKABLE;

            nailBarEntity.Get<CTouchInputListener>();
        }
    }
}
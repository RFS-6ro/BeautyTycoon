using BT.Core.CompositeRoot;
using BT.Meta.Common.Assets.WorkingTools;
using BT.Meta.Common.Assets.WorkingTools.NailBar;
using BT.Meta.Common.Assets.WorkingTools.Selection;
using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneWorkingToolsStartup :
            IUpdateLogicPartStartup<MainSceneWorkingToolsStartup>
    {
        private readonly Camera _camera;
        private readonly Grid _grid;
        private readonly MapMask _mask;
        private readonly WorkingToolPositioningData _workingToolsPositioning;

        public MainSceneWorkingToolsStartup
            (Camera camera, MapMask mask, Grid grid)
        {
            _camera = camera;
            _mask = mask;
            _grid = grid;

            _workingToolsPositioning = Resources.Load<WorkingToolPositioningData>
                ("MainScenePositioning");
        }

        public MainSceneWorkingToolsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SNailBarCreate())
                .Add(new SWorkingToolSelection())
                .Add(new SWorkingToolMove())
                .Inject(_camera)
                .Inject(_mask)
                .Inject(_grid)
                .Inject(_workingToolsPositioning);
            return this;
        }
    }
}
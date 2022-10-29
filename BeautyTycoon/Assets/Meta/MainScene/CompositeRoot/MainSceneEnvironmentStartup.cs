using BT.Core.CompositeRoot;
using BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using BT.Meta.Common.Environment;
using BT.Meta.Common.Environment.World.Destruction;
using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneEnvironmentStartup :
            IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public readonly Camera Camera;
        public readonly TileFactory Factory;
        public readonly Grid Grid;
        public readonly MapMask Mask;
        public readonly MetricsConfiguration Metrics;

        public MainSceneEnvironmentStartup()
        {
            Camera = Camera.main;
            Mask = Resources.Load<MapMask>(nameof(MapMask));
            Metrics = Resources.Load<MetricsConfiguration>
                (nameof(MetricsConfiguration));
            Factory = new TileFactory();
            Grid = Object.Instantiate(Resources.Load<Grid>("Isometric Grid"));

            CellUtils.Initialize(Grid, Mask);
        }

        public MainSceneEnvironmentStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SWorldGenerator())
                .Add(new SWorldDestroyer())
                .Inject(Mask)
                .Inject(Factory)
                .Inject(Grid);

            new MainSceneMetricsStartup()
                .AddUpdateSystems(systems);

            new MainSceneWorkingToolsStartup(Camera, Mask, Grid)
                .AddUpdateSystems(systems);

            return this;
        }
    }
}
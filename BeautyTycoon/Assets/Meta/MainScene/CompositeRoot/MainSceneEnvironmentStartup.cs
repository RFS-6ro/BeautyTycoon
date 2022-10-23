using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using Meta.Common.Environment;
using Meta.Common.Environment.World.Destruction;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEnvironmentStartup : IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public readonly MapMask Mask;
        public readonly MetricsConfiguration Metrics;
        public readonly TileFactory Factory;
        public readonly Grid Grid;
        
        public MainSceneEnvironmentStartup()
        {
            Mask = Resources.Load<MapMask>(nameof(MapMask));
            Metrics = Resources.Load<MetricsConfiguration>(nameof(MetricsConfiguration));
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
            
            new MainSceneWorkingToolsStartup()
                .AddUpdateSystems(systems);

            return this;
        }
    }
}

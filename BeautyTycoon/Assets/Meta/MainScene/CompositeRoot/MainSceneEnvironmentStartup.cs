using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using Meta.Common.Environment.World.Destruction;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEnvironmentStartup : IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public readonly MapMask Mask;
        public readonly TileFactory Factory;
        public readonly UnityEngine.Grid Grid;
        
        public MainSceneEnvironmentStartup()
        {
            Mask = Resources.Load<MapMask>(nameof(MapMask));
            Factory = new TileFactory();
            Grid = Object.Instantiate(Resources.Load<UnityEngine.Grid>("Isometric Grid"));
            
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
            
            new MainSceneDailyScheduleStartup()
                .AddUpdateSystems(systems);
            
            new MainSceneWorkingToolsStartup()
                .AddUpdateSystems(systems);

            return this;
        }
    }
}

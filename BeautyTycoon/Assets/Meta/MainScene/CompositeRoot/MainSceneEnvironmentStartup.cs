using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Environment.World.Destruction;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEnvironmentStartup : IUpdateLogicPartStartup<MainSceneEnvironmentStartup>
    {
        public MainSceneEnvironmentStartup AddUpdateSystems(EcsSystems systems)
        {
            MapMask mask = Resources.Load<MapMask>(nameof(MapMask));
            TileFactory factory = new TileFactory();
            UnityEngine.Grid grid = Resources.Load<UnityEngine.Grid>("Isometric Grid");

            systems
                .Add(new SWorldGenerator())
                .Add(new SWorldDestroyer())
                .Inject(mask)
                .Inject(factory)
                .Inject(grid);
            
            new MainSceneWorkingToolsStartup()
                .AddUpdateSystems(systems);

            return this;
        }
    }
}

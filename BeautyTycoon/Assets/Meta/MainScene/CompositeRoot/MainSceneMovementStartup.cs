using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters;
using Meta.Common.Assets.Characters.Movement;
using Meta.Common.Assets.Characters.MovementApply;
using Meta.Common.Assets.Characters.MovementLogic;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using Meta.Common.World.Creation;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneMovementStartup : 
        IUpdateLogicPartStartup<MainSceneMovementStartup>, 
        IFixedUpdateLogicPartStartup<MainSceneMovementStartup>
    {
        private readonly Camera _camera;
        private readonly Grid _grid;
        private readonly MapMask _mask;
        
        private readonly ICellMovementCalculator _calculator;
        
        public MainSceneMovementStartup(Camera camera, Grid grid, MapMask mask)
        {
            _camera = camera;
            _grid = grid;
            _mask = mask;
            
            _calculator = new AStarCellMovementCalculator(_grid, _mask);
        }
        
        public MainSceneMovementStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SConvertTouchToCellMovement())
                .Inject(_camera);
            return this;
        }

        public MainSceneMovementStartup AddFixedUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SMovementLogic())
                .Add(new SUnitMoveApply())
                .OneFrame<CMovementDelta>()
                .Inject(_calculator);
            return this;
        }
    }
}

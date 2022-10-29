using BT.Core.CompositeRoot;
using BT.Meta.Common.Assets.Characters;
using BT.Meta.Common.Assets.Characters.Movement;
using BT.Meta.Common.Assets.Characters.MovementApply;
using BT.Meta.Common.Assets.Characters.MovementLogic;
using BT.Meta.Common.Assets.Characters.MovementLogic.CellMovement;
using BT.Meta.Common.World.Creation;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneMovementStartup :
        IUpdateLogicPartStartup<MainSceneMovementStartup>,
        IFixedUpdateLogicPartStartup<MainSceneMovementStartup>
    {
        private readonly ICellMovementCalculator _calculator;
        private readonly Camera _camera;
        private readonly Grid _grid;
        private readonly MapMask _mask;

        public MainSceneMovementStartup(Camera camera, Grid grid, MapMask mask)
        {
            _camera = camera;
            _grid = grid;
            _mask = mask;

            _calculator = new AStarCellMovementCalculator(_grid, _mask);
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

        public MainSceneMovementStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SConvertTouchToCellMovement())
                .Inject(_camera);
            return this;
        }
    }
}
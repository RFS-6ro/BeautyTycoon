using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters;
using Meta.Common.Assets.Characters.Movement;
using Meta.Common.Assets.Characters.MovementApply;
using Meta.Common.Assets.Characters.MovementLogic;
using Meta.Common.Assets.Characters.MovementLogic.CellMovement;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneMovementStartup : 
        IUpdateLogicPartStartup<MainSceneMovementStartup>, 
        IFixedUpdateLogicPartStartup<MainSceneMovementStartup>
    {
        private ICellMovementCalculator _calculator;
        
        public MainSceneMovementStartup()
        {
            _calculator = null;
        }
        
        public MainSceneMovementStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SConvertTouchToCellMovement());
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

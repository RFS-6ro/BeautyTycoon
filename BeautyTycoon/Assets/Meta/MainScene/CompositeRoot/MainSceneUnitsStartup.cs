using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.MainCharacter;
using Meta.Common.Assets.Characters.Visitor_default;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUnitsStartup : IUpdateLogicPartStartup<MainSceneUnitsStartup>
    {
        public MainSceneUnitsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SMainCharacterCreate())
                .Add(new SVisitorCreate())
                .OneFrame<CRequestVisitor>()
                .OneFrame<CRequestDeleteVisitor>();
            return this;
        }
    }
}

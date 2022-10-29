using BT.Core.CompositeRoot;
using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.Assets.Characters.Visitor_default;

using Leopotam.Ecs;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneUnitsStartup : IUpdateLogicPartStartup<MainSceneUnitsStartup>
    {
        public MainSceneUnitsStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SMainCharacterCreate())
                .Add(new SVisitorCreate())
                .OneFrame<CRequestVisitor>()
                .OneFrame<CRequestDeleteVisitor>()
                .OneFrame<CVisitorRequestProcess>();
            return this;
        }
    }
}
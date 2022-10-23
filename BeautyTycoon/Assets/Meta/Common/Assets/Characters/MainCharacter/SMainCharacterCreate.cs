using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using Meta.Common.InputHandling;
using UnityEngine;

namespace Meta.Common.Assets.Characters.MainCharacter
{
    public class SMainCharacterCreate : IEcsInitSystem
    {
        private EcsWorld _world;
        
        public void Init()
        {
            CreateMainCharacter();
        }

        private void CreateMainCharacter()
        {
            GameObject mainCharacter = Object.Instantiate(Resources.Load<GameObject>("MainCharacter"));
            var entity = _world.NewEntity();

            ref CUnit unit = ref entity.Get<CUnit>();
            unit.Transform = mainCharacter.transform;

            entity.Get<CKeyboardInputData>();
            entity.Get<CTouchInputListener>();
        }
    }
}

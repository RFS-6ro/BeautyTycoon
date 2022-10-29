using BT.Meta.Common.InputHandling;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.MainCharacter
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
            var mainCharacter = Object.Instantiate
                (Resources.Load<GameObject>("MainCharacter"));
            var entity = _world.NewEntity();

            ref var unit = ref entity.Get<CUnit>();
            unit.Transform = mainCharacter.transform;

            entity.Get<CKeyboardInputData>();
            entity.Get<CTouchInputListener>();
        }
    }
}
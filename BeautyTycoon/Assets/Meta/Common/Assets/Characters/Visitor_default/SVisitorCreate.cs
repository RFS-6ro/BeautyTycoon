using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Assets.Characters.Visitor_default
{
    public class SVisitorCreate : IEcsInitSystem, IEcsRunSystem
    {
        private const int MAX_CHOISE_DATA = 3;
        private EcsFilter<CRequestDeleteVisitor> _deleteVisitorRequestFilter;

        private GameObject _visitor;
        private EcsEntity _visitorEntity;

        private EcsFilter<CRequestVisitor> _visitorRequestFilter;

        private EcsWorld _world;

        public void Init()
        {
            CreateVisitor();
        }

        public void Run()
        {
            foreach (var entityId in _deleteVisitorRequestFilter)
            {
                _visitorEntity.Del<CChoiceVariant>();
                _visitor.SetActive(false);
                break;
            }

            foreach (var entityId in _visitorRequestFilter)
            {
                ref var choiceVariant =
                    ref _visitorEntity.Get<CChoiceVariant>();
                choiceVariant.ChosenData = Random.Range(0, MAX_CHOISE_DATA);
                choiceVariant.MaxChoiceData = MAX_CHOISE_DATA;
                _visitor.SetActive(true);
                break;
            }
        }

        private void CreateVisitor()
        {
            _visitor = Object.Instantiate
                (Resources.Load<GameObject>("Visitor_default"));
            _visitorEntity = _world.NewEntity();

            ref var unit = ref _visitorEntity.Get<CUnit>();
            unit.Transform = _visitor.transform;

            _visitor.SetActive(false);
        }
    }
}
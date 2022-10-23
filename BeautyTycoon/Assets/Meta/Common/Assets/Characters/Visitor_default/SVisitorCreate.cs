using BT.Meta.Common.Characters;
using Leopotam.Ecs;
using UnityEngine;

namespace Meta.Common.Assets.Characters.Visitor_default
{
    public class SVisitorCreate : IEcsInitSystem, IEcsRunSystem
    {
        private const int MAX_CHOISE_DATA = 3;
        
        private EcsWorld _world;
        
        private GameObject _visitor;
        private EcsEntity _visitorEntity;

        private EcsFilter<CRequestVisitor> _visitorRequestFilter;
        private EcsFilter<CRequestDeleteVisitor> _deleteVisitorRequestFilter;

        public void Init()
        {
            CreateVisitor();
        }

        private void CreateVisitor()
        {
            _visitor = Object.Instantiate(Resources.Load<GameObject>("Visitor_default"));
            _visitorEntity = _world.NewEntity();

            ref CUnit unit = ref _visitorEntity.Get<CUnit>();
            unit.Transform = _visitor.transform;
            
            _visitor.SetActive(false);
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
                ref CChoiceVariant choiceVariant = ref _visitorEntity.Get<CChoiceVariant>();
                choiceVariant.ChosenData = Random.Range(0, MAX_CHOISE_DATA);
                choiceVariant.MaxChoiceData = MAX_CHOISE_DATA;
                _visitor.SetActive(true);
                break;
            }
        }
    }
}

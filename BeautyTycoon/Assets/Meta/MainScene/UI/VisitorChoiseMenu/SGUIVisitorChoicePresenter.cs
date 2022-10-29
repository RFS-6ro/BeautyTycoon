using System;

using BT.Meta.Common.Assets.Characters.Visitor_default;
using BT.Meta.Common.Environment;
using BT.Meta.Common.Environment.Balance;
using BT.Meta.Common.Environment.Reputation;
using BT.Meta.MainScene.UI.VisitorChoseMenu.VisitorChoicePanel;

using Leopotam.Ecs;

namespace BT.Meta.MainScene.UI.VisitorChoseMenu
{
    public class SGUIVisitorChoicePresenter : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CChoiceVariant, CVisitorRequestProcess> _filter;
        private MetricsConfiguration _metricsConfiguration;
        private GUIVisitorChoiceMenuView _visitorChoiceMenu;

        public void Init()
        {
            HideMenu();
        }

        public void Run()
        {
            foreach (var entityId in _filter)
            {
                var choiceVariant = _filter.Get1(entityId);
                var entity = _filter.GetEntity(entityId);
                entity.Del<CVisitorRequestProcess>();

                _visitorChoiceMenu.Activate();
                var panels = _visitorChoiceMenu.Show
                    (choiceVariant.MaxChoiceData);

                for (var choice = 0;
                     choice < choiceVariant.MaxChoiceData;
                     choice++)
                {
                    var panel = panels[choice];

                    Action onChoose;
                    if (choice == choiceVariant.ChosenData)
                        onChoose = () => HandleCorrectChoice(entity);
                    else
                        onChoose = () => HandleWrongChoice(entity);

                    panel.ShowChoiceWithAction
                        (choice.ToString(), onChoose, HandleDeclineChoice);
                }

                break;
            }
        }

        private void HideMenu()
        {
            _visitorChoiceMenu.Hide();
        }

        private void HandleWrongChoice(EcsEntity entity)
        {
            ref var reputationChange = ref entity.Get<CReputationChange>();
            reputationChange.Delta =
                _metricsConfiguration.FailedOrderReputation;

            HideMenu();
        }

        private void HandleDeclineChoice
            (GUIVisitorChoiсePanelView choiсePanelView)
        {
            choiсePanelView.SetFirstSibling();
        }

        private void HandleCorrectChoice(EcsEntity entity)
        {
            ref var reputationChange = ref entity.Get<CReputationChange>();
            reputationChange.Delta =
                _metricsConfiguration.SuccessOrderReputation;

            ref var balanceChange = ref entity.Get<CBalanceChange>();
            balanceChange.Delta = _metricsConfiguration.OrderRevenue;

            HideMenu();
        }
    }
}
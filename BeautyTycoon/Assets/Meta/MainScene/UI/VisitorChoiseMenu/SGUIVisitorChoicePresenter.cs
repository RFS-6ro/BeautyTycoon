using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using Meta.Common.Assets.Characters.Visitor_default;
using Meta.Common.Environment;
using Meta.Common.Environment.Balance;
using Meta.Common.Environment.Reputation;
using Meta.MainScene.UI.VisitorChoseMenu.VisitorChoicePanel;

namespace Meta.MainScene.UI.VisitorChoseMenu
{
    public class SGUIVisitorChoicePresenter : IEcsInitSystem, IEcsRunSystem
    {
        private MetricsConfiguration _metricsConfiguration;
        private GUIVisitorChoiceMenuView _visitorChoiceMenu;
        
        private EcsFilter<CChoiceVariant, CVisitorRequestProcess> _filter;

        public void Init()
        {
            HideMenu();
        }
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                CChoiceVariant choiceVariant = _filter.Get1(entityId);
                EcsEntity entity = _filter.GetEntity(entityId);
                entity.Del<CVisitorRequestProcess>();
                
                _visitorChoiceMenu.Activate();
                IList<GUIVisitorChoiсePanelView> panels = _visitorChoiceMenu.Show(choiceVariant.MaxChoiceData);

                for (int choice = 0; choice < choiceVariant.MaxChoiceData; choice++)
                {
                    GUIVisitorChoiсePanelView panel = panels[choice];
                    
                    Action onChoose;
                    if (choice == choiceVariant.ChosenData)
                    {
                        onChoose = () => HandleCorrectChoice(entity);
                    }
                    else
                    {
                        onChoose = () => HandleWrongChoice(entity);
                    }
                    
                    panel.ShowChoiceWithAction(choice.ToString(), onChoose, HandleDeclineChoice);
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
            ref CReputationChange reputationChange = ref entity.Get<CReputationChange>();
            reputationChange.Delta = _metricsConfiguration.FailedOrderReputation;
            
            HideMenu();
        }

        private void HandleDeclineChoice(GUIVisitorChoiсePanelView choiсePanelView)
        {
            choiсePanelView.SetFirstSibling();
        }
        
        private void HandleCorrectChoice(EcsEntity entity)
        {
            ref CReputationChange reputationChange = ref entity.Get<CReputationChange>();
            reputationChange.Delta = _metricsConfiguration.SuccessOrderReputation; 
            
            ref CBalanceChange balanceChange = ref entity.Get<CBalanceChange>();
            balanceChange.Delta = _metricsConfiguration.OrderRevenue;   
            
            HideMenu();
        }
    }
}

using Leopotam.Ecs;
using Meta.Common.Environment;
using Meta.Common.Environment.DailySchedule;
using Meta.Common.Environment.Reputation.Utils;
using Meta.MainScene.SceneReloader;
using UnityEngine;

namespace Meta.MainScene.UI.ResultWindow
{
    public class SGUIResultWindowPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private GUIResultWindowView _resultWindowView;
        private MetricsConfiguration _metrics;

        private EcsFilter<CShiftOver> _filter;

        public void Init()
        {
            _resultWindowView.Deactivate();
        }
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                _resultWindowView.Activate();
                _resultWindowView.Show
                (
                    "Shift results",
                    $"Clients Processed: {CalculateClients()}",
                    $"Reputation delta: {CalculateReputation()}",
                    $"Balance delta: {CalculateBalance()}",
                    $"Rent: -{_metrics.DailyRent}",
                    $"OK",
                    OnCloseResultClick
                );

                _filter.GetEntity(entityId).Del<CShiftOver>();
                break;
            }
        }

        private string CalculateClients()
        {
            int totalVisitorsPrev = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_VISITORS_PREV, 0);
            int totalVisitors = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_VISITORS, 0);
            
            return (totalVisitors - totalVisitorsPrev).ToString();
        }

        private string CalculateReputation()
        {
            int reputationPrev = PlayerPrefs.GetInt(MetricsConfiguration.REPUTATION_PREV, 0);
            int reputation = ReputationUtils.CalculatePercentage();
            
            return AddSignIfNeeded(reputation - reputationPrev);
        }

        private string CalculateBalance()
        {
            int totalBalancePrev = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_BALANCE_PREV, 0);
            int totalBalance = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_BALANCE, _metrics.InitialBalance);

            return AddSignIfNeeded(totalBalance - totalBalancePrev);
        }

        private string AddSignIfNeeded(int value)
        {
            if (value > 0)
            {
                return $"+{value}";
            }

            return value.ToString();
        }
        
        private void OnCloseResultClick()
        {
            _resultWindowView.Deactivate();
            _world.NewEntity().Get<CReloadSceneRequest>();
        }
    }
}

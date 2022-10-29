using BT.Meta.Common.Environment;
using BT.Meta.Common.Environment.DailySchedule;
using BT.Meta.Common.Environment.Reputation.Utils;
using BT.Meta.MainScene.SceneReloader;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.UI.ResultWindow
{
    public class SGUIResultWindowPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CShiftOver> _filter;
        private MetricsConfiguration _metrics;
        private GUIResultWindowView _resultWindowView;
        private EcsWorld _world;

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
                    "OK",
                    OnCloseResultClick
                );

                _filter.GetEntity(entityId)
                    .Del<CShiftOver>();
                break;
            }
        }

        private string CalculateClients()
        {
            var totalVisitorsPrev = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_VISITORS_PREV, 0);
            var totalVisitors = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_VISITORS, 0);

            PlayerPrefs.SetInt
                (MetricsConfiguration.TOTAL_VISITORS_PREV, totalVisitors);
            PlayerPrefs.Save();
            return (totalVisitors - totalVisitorsPrev).ToString();
        }

        private string CalculateReputation()
        {
            var reputationPrev = PlayerPrefs.GetInt
                (MetricsConfiguration.REPUTATION_PREV, 0);
            var reputation = ReputationUtils.CalculatePercentage();

            PlayerPrefs.SetInt
                (MetricsConfiguration.REPUTATION_PREV, reputation);
            PlayerPrefs.Save();

            return AddSignIfNeeded(reputation - reputationPrev);
        }

        private string CalculateBalance()
        {
            var totalBalancePrev = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_BALANCE_PREV, 0);
            var totalBalance = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_BALANCE, _metrics.InitialBalance);

            return AddSignIfNeeded(totalBalance - totalBalancePrev);
        }

        private string AddSignIfNeeded(int value)
        {
            if (value > 0) return $"+{value}";

            return value.ToString();
        }

        private void OnCloseResultClick()
        {
            _resultWindowView.Deactivate();
            _world.NewEntity()
                .Get<CReloadSceneRequest>();
        }
    }
}
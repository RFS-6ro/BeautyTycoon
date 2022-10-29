using BT.Meta.Common.Environment.Balance;
using BT.Meta.Common.Environment.DailySchedule;
using BT.Meta.Common.Environment.Reputation;

using Leopotam.Ecs;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUITopBarPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CBalance> _balanceFilter;
        private EcsFilter<CReputation> _reputationFilter;

        private EcsFilter<CShiftOver> _shiftOverFilter;

        private EcsFilter<CWorldTime> _timeFilter;
        private GUITopBarView _topBarPresenter;

        public void Init()
        {
            _topBarPresenter.Activate();
        }

        //possible class split, but not necessary
        public void Run()
        {
            if (!_topBarPresenter.IsShown) return;

            foreach (var entityId in _timeFilter)
            {
                _topBarPresenter.ShowTime
                (
                    _timeFilter.Get1(entityId)
                        .Time.ToString12Hours()
                );
                break;
            }

            foreach (var entityId in _reputationFilter)
            {
                _topBarPresenter.ShowReputation
                    ($"{_reputationFilter.Get1(entityId).Percentage}%");
                break;
            }

            foreach (var entityId in _balanceFilter)
            {
                _topBarPresenter.ShowBalance
                    ($"{_balanceFilter.Get1(entityId).Amount}$");
                break;
            }

            foreach (var entityId in _shiftOverFilter)
            {
                _topBarPresenter.Deactivate();
                break;
            }
        }
    }
}
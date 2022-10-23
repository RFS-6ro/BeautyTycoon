using Leopotam.Ecs;
using Meta.Common.Environment.Balance;
using Meta.Common.Environment.DailySchedule;
using Meta.Common.Environment.Reputation;

namespace BT.Meta.MainScene.UI.TopBar
{
    public class SGUITopBarPresenter : IEcsInitSystem, IEcsRunSystem
    {
        private GUITopBarView _topBarPresenter;

        private EcsFilter<CWorldTime> _timeFilter;
        private EcsFilter<CReputation> _reputationFilter;
        private EcsFilter<CBalance> _balanceFilter;
        
        private EcsFilter<CShiftOver> _shiftOverFilter;

        public void Init()
        {
            _topBarPresenter.Activate();
        }
        
        //possible class split, but not necessary
        public void Run()
        {
            if (!_topBarPresenter.IsShown) { return; }
            
            foreach (var entityId in _timeFilter)
            {
                _topBarPresenter.ShowTime(_timeFilter.Get1(entityId).Time.ToString12Hours());
                break;
            }
            foreach (var entityId in _reputationFilter)
            {
                _topBarPresenter.ShowReputation(_reputationFilter.Get1(entityId).Percentage.ToString());
                break;
            }
            foreach (var entityId in _balanceFilter)
            {
                _topBarPresenter.ShowTime(_balanceFilter.Get1(entityId).Amount.ToString());
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

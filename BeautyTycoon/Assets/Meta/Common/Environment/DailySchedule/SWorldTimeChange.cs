using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Environment.DailySchedule
{
    public class SWorldTimeChange : IEcsInitSystem, IEcsRunSystem
    {
        private WorldTimeConfiguration _configuration;
        private float _lastUpdateTime;
        private EcsFilter<CShiftOver> _shiftOverFilter;

        private EcsFilter<CWorldTime> _timeFilter;
        private EcsWorld _world;

        public void Init()
        {
            _configuration = Resources.Load<WorldTimeConfiguration>
                ("TimeConfiguration");
            _configuration.Init();

            _lastUpdateTime = Time.time;

            ref var worldTime = ref _world.NewEntity()
                .Get<CWorldTime>();
            worldTime.Time = _configuration.ShiftStartTime.Clone();
        }

        public void Run()
        {
            foreach (var entityId in _shiftOverFilter) return;

            if (Time.time - _lastUpdateTime
                < _configuration.TimeUpdateDelayInSeconds)
                return;

            foreach (var entityId in _timeFilter)
            {
                ref var worldTime = ref _timeFilter.Get1(entityId);
                worldTime.Time.AddMinutes(_configuration.TimeDelta);

                if (IsShiftOver(worldTime.Time))
                    _timeFilter.GetEntity(entityId)
                        .Get<CShiftOver>();
                break;
            }

            _lastUpdateTime = Time.time;
        }

        private bool IsShiftOver(SimpleTimeType currentTime)
        {
            return currentTime.ToMinutes()
                   >= _configuration.ShiftEndTime.ToMinutes();
        }
    }
}
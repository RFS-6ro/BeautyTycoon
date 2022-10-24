using Leopotam.Ecs;
using UnityEngine;

namespace Meta.Common.Environment.DailySchedule
{
    public class SWorldTimeChange : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;

        private WorldTimeConfiguration _configuration;
        private float _lastUpdateTime;

        private EcsFilter<CWorldTime> _filter;

        public void Init()
        {
            _configuration = Resources.Load<WorldTimeConfiguration>("TimeConfiguration");
            _configuration.Init();
            
            _lastUpdateTime = Time.time;
            
            ref CWorldTime worldTime = ref _world.NewEntity().Get<CWorldTime>();
            worldTime.Time = _configuration.ShiftStartTime.Clone();
        }
        
        public void Run()
        {
            if (Time.time - _lastUpdateTime < _configuration.TimeUpdateDelayInSeconds) { return; }
            
            foreach (var entityId in _filter)
            {
                ref CWorldTime worldTime = ref _filter.Get1(entityId);
                worldTime.Time.AddMinutes(_configuration.TimeDelta);

                if (IsShiftOver(worldTime.Time))
                {
                    _filter.GetEntity(entityId).Get<CShiftOver>();
                }
                break;
            }

            _lastUpdateTime = Time.time;
        }

        private bool IsShiftOver(SimpleTimeType currentTime)
        {
            return currentTime.ToMinutes() >= _configuration.ShiftEndTime.ToMinutes();
        }
    }
}

using System;
using UnityEngine;

namespace Meta.Common.Environment.DailySchedule
{
    [CreateAssetMenu(fileName = "TimeConfiguration", menuName = "Environment/WorldConfigs/TimeConfiguration", order = 3)]
    public class WorldTimeConfiguration : ScriptableObject
    {
        public SimpleTimeType ShiftStartTime;

        public SimpleTimeType ShiftEndTime;

        public int ShiftDurationInSecondsRealtime;
        
        public int TimeUpdateTickRateInSeconds = 5;

        //TODO: consider result caching 
        public int TimeDelta =>
            (ShiftEndTime.ToMinutes() - ShiftStartTime.ToMinutes()) / ShiftDurationInSecondsRealtime * TimeUpdateTickRateInSeconds;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (ShiftEndTime.ToMinutes() <= ShiftStartTime.ToMinutes())
            {
                Debug.LogError("Shift end time is less, than shift start time. Values were updated");
                ShiftEndTime.AddHours(8);
            }
        }
#endif
    }
}

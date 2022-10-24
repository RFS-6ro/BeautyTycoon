using System;
using UnityEngine;

namespace Meta.Common.Environment.DailySchedule
{
    [CreateAssetMenu(fileName = "TimeConfiguration", menuName = "Environment/WorldConfigs/TimeConfiguration", order = 3)]
    public class WorldTimeConfiguration : ScriptableObject
    {
        public SimpleTimeType ShiftStartTime = new SimpleTimeType(10, 0);

        public SimpleTimeType ShiftEndTime = new SimpleTimeType(20, 0);

        public int ShiftDurationInSecondsRealtime = 300;
        
        public int TimeUpdateDelayInSeconds = 5;

        public int TimeDelta;

        public void Init()
        {
            CalculateTimeDelta();
        }

        private void CalculateTimeDelta()
        {
            TimeDelta = (ShiftEndTime.ToMinutes() - ShiftStartTime.ToMinutes()) / ShiftDurationInSecondsRealtime * TimeUpdateDelayInSeconds;
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (ShiftEndTime.ToMinutes() <= ShiftStartTime.ToMinutes())
            {
                Debug.LogError("Shift end time is less, than shift start time. Values were updated");
                ShiftEndTime.AddHours(8);
            }

            CalculateTimeDelta();
        }
#endif
    }
}

using System;

namespace Meta.Common.Environment.DailySchedule
{
    [Serializable]
    public class SimpleTimeType
    {
        public const int HOURS_MAX = 24;
        public const int MINUTES_MAX = 60;

        public int Hour;
        public int Minute;

        public SimpleTimeType(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
        
        public void AddHours(int hours)
        {
            Hour = (Hour + hours) % HOURS_MAX;
        }

        public void AddMinutes(int minutes)
        {
            int nextMinutesTime = Minute + minutes;
            Minute = nextMinutesTime % MINUTES_MAX;
            AddHours(nextMinutesTime / MINUTES_MAX);
        }

        public int ToMinutes()
        {
            return Hour * MINUTES_MAX + Minute;
        }
        
        public string ToString24Hours()
        {
            return $"{Hour % HOURS_MAX}:{FormatMinutes()}";
        }
        
        public string ToString12Hours()
        {
            string postfix = "AM";
            int hour12 = Hour % HOURS_MAX;

            if (hour12 == 0)
            {
                hour12 = 12;
            }
            else if (hour12 == 12)
            {
                postfix = "PM";
            }
            else if (hour12 > 12)
            {
                hour12 -= 12;
                postfix = "PM";
            }

            return $"{hour12}:{FormatMinutes()} {postfix}";
        }

        private string FormatMinutes()
        {
            int minutes = Minute % MINUTES_MAX;
            
            if (minutes == 0) { return "00"; }

            return minutes.ToString();
        }

        public SimpleTimeType Clone()
        {
            return new SimpleTimeType(Hour, Minute);
        }
    }
}

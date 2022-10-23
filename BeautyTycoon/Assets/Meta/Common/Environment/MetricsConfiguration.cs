using UnityEngine;

namespace Meta.Common.Environment
{
    [CreateAssetMenu(fileName = "MetricsConfiguration", menuName = "Environment/WorldConfigs/MetricsConfiguration", order = 4)]
    public class MetricsConfiguration : ScriptableObject
    {
        public int InitialBalance = 125;
        
        public int OrderRevenue = 100;
        public int DailyRent = 50;
        
        public int SuccessOrderReputation = 1;
        public int FailedOrderReputation = -1;
    }
}
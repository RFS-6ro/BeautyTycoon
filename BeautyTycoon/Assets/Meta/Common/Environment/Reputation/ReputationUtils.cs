using UnityEngine;

namespace BT.Meta.Common.Environment.Reputation.Utils
{
    public static class ReputationUtils
    {
        public static int CalculatePercentage()
        {
            var totalVisitors = PlayerPrefs.GetInt
                (MetricsConfiguration.TOTAL_VISITORS, 0);

            if (totalVisitors == 0) return 100;

            var successfullyProcessedVisitors = PlayerPrefs.GetInt
                (MetricsConfiguration.SUCCESS_PROCESSED, 0);

            return successfullyProcessedVisitors / totalVisitors;
        }
    }
}
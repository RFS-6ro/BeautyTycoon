using UnityEngine;

namespace Meta.Common.Environment.Reputation.Utils
{
    public static class ReputationUtils
    {
        public static int CalculatePercentage()
        {
            int totalVisitors = PlayerPrefs.GetInt(MetricsConfiguration.TOTAL_VISITORS, 0);

            if (totalVisitors == 0)
            {
                return 100;
            }
            
            int successfullyProcessedVisitors = PlayerPrefs.GetInt(MetricsConfiguration.SUCCESS_PROCESSED, 0);

            return successfullyProcessedVisitors / totalVisitors;
        }
    }
}

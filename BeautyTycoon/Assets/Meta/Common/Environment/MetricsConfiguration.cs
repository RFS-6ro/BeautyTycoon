using UnityEngine;

namespace BT.Meta.Common.Environment
{
    [CreateAssetMenu
    (
        fileName = "MetricsConfiguration",
        menuName = "Environment/WorldConfigs/MetricsConfiguration", order = 4
    )]
    public class MetricsConfiguration : ScriptableObject
    {
        public const string TOTAL_BALANCE_PREV = "TotalBalancePreviousDay";
        public const string REPUTATION_PREV = "TotalBalancePreviousDay";
        public const string TOTAL_VISITORS_PREV = "TotalVisitorsPreviousDay";

        public const string TOTAL_BALANCE = "TotalBalance";

        public const string TOTAL_VISITORS = "TotalVisitors";
        public const string SUCCESS_PROCESSED = "SuccessfullyProcessedVisitors";

        public int InitialBalance = 125;

        public int OrderRevenue = 100;
        public int DailyRent = 50;

        public int SuccessOrderReputation = 1;
        public int FailedOrderReputation = -1;
    }
}
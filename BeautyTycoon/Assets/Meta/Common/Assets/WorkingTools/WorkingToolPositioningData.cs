using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace BT.Meta.Common.Assets.WorkingTools
{
    [CreateAssetMenu
    (
        fileName = "WorkingToolPositioning",
        menuName = "Environment/WorldConfigs/WorkingToolPositioning", order = 4
    )]
    public class WorkingToolPositioningData : ScriptableObject
    {
        public List<WorkingToolData> WorkingToolsData;

        public WorkingToolData GetWorkingToolData(WorkingToolsClassification classification)
        {
            return WorkingToolsData.FirstOrDefault(data => data.Class == classification);
        }

        [Serializable]
        public class WorkingToolData
        {
            public WorkingToolsClassification Class;
            public GameObject Prefab;
            public List<Vector3Int> Positions;
        }
    }
}
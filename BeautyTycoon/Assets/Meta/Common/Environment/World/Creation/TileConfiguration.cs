using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Common.World.Creation
{
    [CreateAssetMenu(fileName = "TileConfiguration", menuName = "Environment/WorldConfigs/TileConfiguration", order = 2)]
    public class TileConfiguration : ScriptableObject
    {
        [Serializable]
        public class TileReference
        {
            public GameObject Prefab;
            public int Type;
        }

        public List<TileReference> TileReferences;
    }
}

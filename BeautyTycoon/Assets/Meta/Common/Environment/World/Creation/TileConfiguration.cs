using System;
using System.Collections.Generic;

using UnityEngine;

namespace BT.Meta.Common.World.Creation
{
    [CreateAssetMenu
    (
        fileName = "TileConfiguration",
        menuName = "Environment/WorldConfigs/TileConfiguration", order = 2
    )]
    public class TileConfiguration : ScriptableObject
    {
        public List<TileReference> TileReferences;

        [Serializable]
        public class TileReference
        {
            public GameObject Prefab;
            public int Type;
        }
    }
}
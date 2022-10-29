using System.Linq;

using UnityEngine;

namespace BT.Meta.Common.World.Creation
{
    public class TileFactory
    {
        private readonly TileConfiguration _configuration;

        public TileFactory()
        {
            _configuration = Resources.Load<TileConfiguration>
                (nameof(TileConfiguration));
        }

        public GameObject GetTile(int tileType)
        {
            GameObject result = null;

            var reference =
                _configuration.TileReferences.FirstOrDefault
                    (tileReference => tileReference.Type == tileType);

            if (reference != null) result = reference.Prefab;

            return result;
        }
    }
}
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.Common.Environment.World.Destruction
{
    public class SWorldDestroyer : IEcsDestroySystem
    {
        private EcsFilter<CWorldTile> _filter;

        public void Destroy()
        {
            foreach (var entityId in _filter)
                Object.Destroy
                (
                    _filter.Get1(entityId)
                        .Tile
                );
        }
    }
}
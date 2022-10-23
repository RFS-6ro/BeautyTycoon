using Leopotam.Ecs;
using Meta.Common.Environment.World;
using UnityEngine;

namespace Meta.Common.World.Creation
{
    public class SWorldGenerator : IEcsInitSystem
    {
        private EcsWorld _world;
        private MapMask _mask;
        private TileFactory _factory;
        private Grid _grid;
        
        public void Init()
        {
            _mask.GenerateMap();
            _mask.Map.ForEachCell(HandleCell);
        }

        private void HandleCell(int x, int y)
        {
            GameObject tilePrefab = _factory.GetTile(_mask.Map[x, y]);

            if (tilePrefab == null)
            {
#if DEBUG
                Debug.LogWarning($"unsupported tile type: {_mask.Map[x, y]}");               
#endif
                return;
            }
                    
            GameObject tile = CreateTile(tilePrefab, _mask.StartPoint, x, y);
                    
            CreateTileEntity(tile);
        }
        
        private GameObject CreateTile(GameObject prefab, Vector3 startPoint, int x, int y)
        {
            GameObject tile = Object.Instantiate(prefab);
            
            tile.name = $"Cell [{x}, {y}]";
            tile.transform.position = startPoint + _grid.GetCellCenterWorld(new Vector3Int(x, y, 0));;
            tile.transform.parent = _grid.transform;

            return tile;
        }

        private void CreateTileEntity(GameObject tileInstance)
        {
            ref CWorldTile tileEntity = ref _world.NewEntity().Get<CWorldTile>();
            tileEntity.Tile = tileInstance;   
        }
    }
}

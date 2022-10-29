using UnityEngine;

namespace BT.Meta.Common.World.Creation
{
    [CreateAssetMenu
    (
        fileName = "MapMask", menuName = "Environment/WorldConfigs/MapMask",
        order = 1
    )]
    public class MapMask : ScriptableObject
    {
        public const int WALKABLE = 0;
        public const int NON_WALKABLE = 1;

        public Vector3 StartPoint;

        [SerializeField] private int _width;
        [SerializeField] private int _height;

        public int[,] Map;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_width <= 0) _width = 1;

            if (_height <= 0) _height = 1;
        }
#endif

        public void GenerateMap()
        {
            ClearOldMap();
            GenerateArray();
            MarkBordersAsNonWalkable();
        }

        private void ClearOldMap()
        {
            Map = null;
        }

        private void GenerateArray()
        {
            Map = new int[_width + 2, _height + 2];
        }

        private void MarkBordersAsNonWalkable()
        {
            for (var x = 0; x < _width + 2; x++)
            {
                Map[x, 0] = NON_WALKABLE;
                Map[x, _height + 1] = NON_WALKABLE;
            }

            for (var y = 1; y < _height + 1; y++)
            {
                Map[0, y] = NON_WALKABLE;
                Map[_width + 1, y] = NON_WALKABLE;
            }
        }
    }
}
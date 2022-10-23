using System;
using Core.Utils;

namespace Meta.Common.Environment.World
{
    public static class GridUtils
    {
        public static void ForEachCell<T>(this T[,] grid, Action<int, int> onCellAction)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    onCellAction.SafeInvoke(x, y);
                }
            }
        }
    }
}

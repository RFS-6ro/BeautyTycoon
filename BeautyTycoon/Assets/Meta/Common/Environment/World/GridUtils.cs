using System;

using BT.Core.Utils;

namespace BT.Meta.Common.Environment.World
{
    public static class GridUtils
    {
        public static void ForEachCell<T>
            (this T[,] grid, Action<int, int> onCellAction)
        {
            for (var x = 0; x < grid.GetLength(0); x++)
            for (var y = 0; y < grid.GetLength(1); y++)
                onCellAction.SafeInvoke(x, y);
        }

        public static bool Inside<T>(this T[,] grid, int x, int y)
        {
            return x < grid.GetLength(0) && y < grid.GetLength(1);
        }
    }
}
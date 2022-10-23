using System;

namespace AI.A_Star
{
    public readonly struct Vector2Int : IEquatable<Vector2Int>
    {
        private static readonly double Sqr = Math.Sqrt(2);
        private readonly int hash;
        
        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
            hash = x.GetHashCode() + y.GetHashCode();
        }

        public int X { get; }
        public int Y { get; }
        
        /// <summary>
        /// Estimated path distance without obstacles.
        /// </summary>
        public double DistanceEstimate()
        {
            int linearSteps = Math.Abs(Math.Abs(Y) - Math.Abs(X));
            int diagonalSteps = Math.Max(Math.Abs(Y), Math.Abs(X)) - linearSteps;
            return linearSteps + Sqr * diagonalSteps;
        }
        
        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);

        public static implicit operator AI.A_Star.Vector2Int(UnityEngine.Vector2Int u) => new AI.A_Star.Vector2Int(u.x, u.y);
        public static implicit operator UnityEngine.Vector2Int(AI.A_Star.Vector2Int a) => new UnityEngine.Vector2Int(a.X, a.Y);
        
        public static implicit operator AI.A_Star.Vector2Int(UnityEngine.Vector3Int u) => new AI.A_Star.Vector2Int(u.x, u.y);
        public static implicit operator UnityEngine.Vector3Int(AI.A_Star.Vector2Int a) => new UnityEngine.Vector3Int(a.X, a.Y, 0);
        
        public bool Equals(Vector2Int other)
            => X.Equals(other.X) && Y.Equals(other.Y);

        public override int GetHashCode()
            => hash;

        public override string ToString()
            => $"({X}, {Y})";
    }
}
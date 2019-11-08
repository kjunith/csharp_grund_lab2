using System;
namespace Labb2
{
    public class Position
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set
            {
                if (value >= 0)
                {
                    _x = value;
                }
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (value >= 0)
                {
                    _y = value;
                }
            }
        }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public bool Equals(Position p)
        {
            return X.Equals(p.X) && Y.Equals(p.Y);
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public static bool operator > (Position p1, Position p2)
        {
            return p1.Length() > p2.Length();
        }

        public static bool operator < (Position p1, Position p2)
        {
            return p1.Length() < p2.Length();
        }

        public static Position operator + (Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static double operator % (Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
    
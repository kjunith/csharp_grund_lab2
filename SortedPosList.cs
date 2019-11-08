using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Labb2
{
    public class SortedPosList
    {
        private List<Position> posList;

        public SortedPosList() {
            posList = new List<Position>();
        }

        public int Count()
        {
            return posList.Capacity;
        }

        public void Add(Position p)
        {
            posList.Add(p);
            posList.OrderBy(pos => pos.Length());
        }

        public bool Remove(Position p)
        {
            List<Position> temp = posList;
            if (temp.Contains(p))
            {
                posList.Remove(p);
                return true;
            }

            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList instance = new SortedPosList();

            instance.posList = posList;

            return instance;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList instance = new SortedPosList();

            foreach (Position p in posList)
            {
                if (Math.Pow(p.X - centerPos.X, 2) + Math.Pow(p.Y - centerPos.Y, 2) < Math.Pow(radius, 2))
                {
                    instance.Add(p);
                }
            }

            return instance;
        }

        public static SortedPosList operator +(SortedPosList posList1, SortedPosList posList2)
        {
            SortedPosList instance = posList1.Clone();

            foreach (Position p in posList2.posList)
            {
                instance.posList.Add(p);
            }

            return instance;
        }

        public Position GetPosition(int pos)
        {
            return posList[pos];
        }

        public static SortedPosList operator -(SortedPosList posList1, SortedPosList posList2)
        {
            SortedPosList instance = posList1.Clone();

            foreach (Position p in posList2.posList)
            {
                if (instance.posList.Contains(p))
                {
                    instance.Remove(p);
                }
            }

            return instance;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SortedPosList:\n");

            for (int i = 0; i < posList.Count; i++)
            {
                builder.Append(posList[i].ToString());

                if (i != posList.Count - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }
    }
}

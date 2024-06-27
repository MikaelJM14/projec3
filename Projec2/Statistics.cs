using System;
namespace Projec2
{
    public class Statistics
    {
        public double First;
        public double Last;
        public double Total;
        public int Count;

        public Statistics()
        {
            Count = 0;
            Total = 0.0;
            First = double.MinValue;
            Last = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Total / Count;
            }
        }

        public void Add(double number)
        {
            Total += number;
            Count += 1;
            Last = Math.Min(number, Last);
            First = Math.Max(number, First);
        }
    }
}

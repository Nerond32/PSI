using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    [Serializable]
    public class City
    {
        public Point Pos { get; set; }
        public int Nr { get; set; }
        public String Name { get; set; }
        public City(int x, int y, int nr, String name)
        {
            Pos = new Point(x, y);
            Nr = nr;
            Name = name;
        }
        public static double TravelCostBetweenCities(City c1, City c2)
        {
            return Math.Sqrt(Math.Pow(c1.Pos.X -c2.Pos.X, 2) + Math.Pow(c1.Pos.Y - c2.Pos.Y, 2));
        }
    }
}

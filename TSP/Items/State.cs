﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    [Serializable]
    public class State
    {
        public double Cost { get; set; }
        public double Heuristic { get; set; }
        public List<Int16> path;
        public State()
        {
            Cost = 0;
            Heuristic = 0;
            path = new List<Int16>();
        }
        public void AddCityToPath(City c)
        {
            path.Add((Int16)c.Nr);
        }
        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }
        public static List<State> Sort(List<State> statesToSort, int criteria)
        {
            List<State> sortedList = new List<State>();
            if (criteria == 1)
            {
                sortedList = statesToSort.OrderBy(o => o.Cost).ToList();
            }
            else if (criteria == 2)
            {
                sortedList = statesToSort.OrderBy(o => o.Heuristic).ToList();
            }
            else Console.WriteLine("Wrong sorting criteria");
            return sortedList;
        }
    }
}

using System;
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
        public List<City> path;
        public State()
        {
            Cost = 0;
            Heuristic = 0;
            path = new List<City>();
        }
        public void AddCityToPath(City c)
        {
            path.Add(c);
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
    }
}

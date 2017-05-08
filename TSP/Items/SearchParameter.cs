using System.Collections.Generic;

namespace TSP
{
    class SearchParameter
    {
        public int Amount { get; set; }
        public bool Visualize { get; set; }
        public bool ReturnToStart { get; set; }
        public List<City> AllCities = new List<City>();
    }
}

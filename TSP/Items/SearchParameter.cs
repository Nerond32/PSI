using System.Collections.Generic;

namespace TSP
{
    class SearchParameter
    {
        public int Amount { get; set; }
        public bool Visualize { get; set; }
        public bool ReturnToStart { get; set; }
        public List<City> AllCities = new List<City>();
        public bool IsMutating { get; set; }
        public int Population { get; set; }
        public int NumberOfGenerations { get; set; }
        public float MutationChance { get; set; }
    }
}

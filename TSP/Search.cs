using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP
{
    class Search
    {
        private static DrawingBoard f;
        private List<int> path = new List<int>();
        public List<City> AllCities { get; set; }
        public List<State> states = new List<State>();
        private int amount;
        public Search(int amount, DrawingBoard f)
        {
            this.amount = amount;
            Search.f = f;
            AllCities = new List<City>();
        }
        public void Start()
        {
            RandomizeLocations();
            State alpha = new State();
            alpha.AddCityToPath(AllCities[0]);
            states = ChildStates(alpha);
        }
        private List<State> ChildStates(State parentState)
        {
            List<City> unvisitedCities = new List<City>(AllCities);
            foreach (City c in parentState.path)
            {
                unvisitedCities.Remove(unvisitedCities.Single(s => s.Nr == c.Nr));
            }
            List<State> childStates = new List<State>();
            if (unvisitedCities.Count == 0)
            {
                parentState.AddCityToPath(AllCities[0]); // Comment these 2 lines to ignore ending at starting point
                parentState.Cost += City.TravelCostBetweenCities(parentState.path[parentState.path.Count - 2], AllCities[0]); //
                childStates.Add(parentState);
                return childStates;
            }
            else
            {
                foreach (City c in unvisitedCities)
                {
                    State child = (State)State.DeepClone(parentState);
                    child.AddCityToPath(c);
                    f.DrawPath(child, AllCities);
                    Thread.Sleep(200); //Can be commented, added so visualisation is not too fast
                    child.Cost += City.TravelCostBetweenCities(child.path[child.path.Count - 2], c);
                    List<State> tmp = ChildStates(child);
                    foreach (State s in tmp)
                    {
                        childStates.Add(s);
                    }
                }
                return childStates;
            }
        }
        public void RandomizeLocations()
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                path.Add(i);
                String cName = "city" + i;
                AllCities.Add(new City(rnd.Next(1, 400), rnd.Next(1, 400), i, cName));
            }
        }
        public void Sort(int criteria)
        {
            states = Sort(states, criteria);
        }
        private static List<State> Sort(List<State> statesToSort, int criteria)
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

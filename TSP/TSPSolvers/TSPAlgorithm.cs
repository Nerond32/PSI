using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    abstract class TSPAlgorithm
    {
        protected SearchParameter SearchInfo { get; set; }
        protected DrawingBoard DrawingBoard { get; set; }
        public TSPAlgorithm(SearchParameter searchInfo, DrawingBoard drawingBoard)
        {
            SearchInfo = searchInfo;
            DrawingBoard = drawingBoard;
        }
        public abstract List<State> ChildStates(State parentState);
        protected static List<Int16> FilterUnvisitedCities(List<Int16> filter, List<City> cities)
        {
            List<Int16> unvisitedCities = new List<Int16>();
            foreach (City c in cities)
            {
                unvisitedCities.Add((Int16)c.Nr);
            }
            foreach (Int16 f in filter)
            {
                try
                {
                    unvisitedCities.Remove(unvisitedCities.Single(s => s == f));
                }
                catch (InvalidOperationException)
                {
                }
            }
            return unvisitedCities;
        }
        protected List<State> ReturnBottomChild(State parentState, List<State> childStates)
        {
            if (SearchInfo.ReturnToStart)
            {
                parentState.AddCityToPath(SearchInfo.AllCities[0]);
                parentState.Cost += City.TravelCostBetweenCities(SearchInfo.AllCities[parentState.path[parentState.path.Count - 2]], SearchInfo.AllCities[0]);
            }
            childStates.Add(parentState);
            return childStates;
        }
    }
}

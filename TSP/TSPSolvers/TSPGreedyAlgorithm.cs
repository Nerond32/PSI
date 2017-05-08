using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP.TSPSolvers
{
    class TSPGreedyAlgorithm : TSPAlgorithm
    {
        public TSPGreedyAlgorithm(SearchParameter searchInfo, DrawingBoard drawingBoard) : base(searchInfo, drawingBoard)
        {
        }

        public override List<State> ChildStates(State parentState)
        {
            List<State> childStates = new List<State>();
            State child = (State)State.DeepClone(parentState);
            while (FilterUnvisitedCities(child.path, SearchInfo.AllCities).Count != 0)
            {
                child.AddCityToPath(GetClosestCity(FilterUnvisitedCities(child.path, SearchInfo.AllCities), SearchInfo.AllCities[child.path[child.path.Count - 1]]));
                if (SearchInfo.Visualize)
                {
                    DrawingBoard.DrawPath(child, SearchInfo.AllCities);
                    Thread.Sleep(500);
                }
            }
            return ReturnBottomChild(child, childStates);
        }

        public City GetClosestCity(List<Int16> targetCities, City sourceCity)
        {
            double leastCost = Double.MaxValue;
            City closestCity = null;
            foreach (Int16 target in targetCities)
            {
                if (City.TravelCostBetweenCities(sourceCity, SearchInfo.AllCities[target]) < leastCost)
                {
                    leastCost = City.TravelCostBetweenCities(sourceCity, SearchInfo.AllCities[target]);
                    closestCity = SearchInfo.AllCities[target];
                }
            }
            return closestCity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP
{
    class BruteForceDFS_TSPAlgorithm : TSPAlgorithm
    {
        public BruteForceDFS_TSPAlgorithm(SearchParameter searchInfo, DrawingBoard drawingBoard) : base(searchInfo, drawingBoard)
        {
        }
        public override List<State> ChildStates(State parentState)
        {
            List<Int16> unvisitedCities = FilterUnvisitedCities(parentState.path, SearchInfo.AllCities);
            List<State> childStates = new List<State>();
            if (unvisitedCities.Count == 0)
            {
                return ReturnBottomChild(parentState, childStates);
            }
            else
            {
                foreach (Int16 c in unvisitedCities)
                {
                    State child = (State)State.DeepClone(parentState);
                    child.AddCityToPath(SearchInfo.AllCities[c]);
                    if (SearchInfo.Visualize)
                    {
                        DrawingBoard.DrawPath(child, SearchInfo.AllCities);
                        Thread.Sleep(500);
                    }
                    child.Cost += City.TravelCostBetweenCities(SearchInfo.AllCities[child.path[child.path.Count - 2]], SearchInfo.AllCities[c]);
                    List<State> tmp = ChildStates(child);
                    foreach (State s in tmp)
                    {
                        childStates.Add(s);
                    }
                }
                return childStates;
            }
        }
    }
}

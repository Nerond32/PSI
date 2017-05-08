using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP.TSPSolvers
{
    class BruteForceBFS_TSPAlgorithm : TSPAlgorithm
    {
        protected Queue<State> bfsQueue = new Queue<State>();
        public BruteForceBFS_TSPAlgorithm(SearchParameter searchInfo, DrawingBoard drawingBoard) : base(searchInfo, drawingBoard)
        {
        }
        public override List<State> ChildStates(State parentState)
        {
            List<Int16> unvisitedCities = FilterUnvisitedCities(parentState.path, SearchInfo.AllCities);
            List<State> childStates = new List<State>();
            bfsQueue.Enqueue(parentState);
            while (bfsQueue.Count != 0)
            {
                if (bfsQueue.Peek().path.Count == SearchInfo.Amount)
                {
                    ReturnBottomChild(bfsQueue.Dequeue(), childStates);
                }
                else
                {
                    foreach (Int16 c in FilterUnvisitedCities(bfsQueue.Peek().path, SearchInfo.AllCities))
                    {
                        State child = (State)State.DeepClone(bfsQueue.Peek());
                        child.AddCityToPath(SearchInfo.AllCities[c]);
                        if (SearchInfo.Visualize)
                        {
                            DrawingBoard.DrawPath(child, SearchInfo.AllCities);
                            Thread.Sleep(500);
                        }
                        child.Cost += City.TravelCostBetweenCities(SearchInfo.AllCities[child.path.Count - 2], SearchInfo.AllCities[c]);
                        bfsQueue.Enqueue(child);
                    }
                    bfsQueue.Dequeue();
                }
            }
            return childStates;
        }
    }
}

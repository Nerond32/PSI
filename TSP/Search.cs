using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TSP
{
    class Search
    {
        public enum Algorithm
        {
            BruteForceDSF,
            BruteForceBSF
        };
        private SearchParameter Input { get; set; }
        private static DrawingBoard drawingBoard;
        private List<Int16> path = new List<Int16>();
        public List<City> AllCities { get; set; }
        public List<State> states = new List<State>();
        public Search(DrawingBoard drawingBoard, SearchParameter Input)
        {
            this.Input = Input;
            Search.drawingBoard = drawingBoard;
            AllCities = new List<City>();
        }
        public void Start()
        {
            RandomizeLocations();
            State alpha = new State();
            alpha.AddCityToPath(AllCities[0]);
            switch ((Algorithm)Input.Method)
            {
                case Algorithm.BruteForceDSF:
                    {
                        states = ChildStatesDSF(alpha);
                        break;
                    }
                case Algorithm.BruteForceBSF:
                    {
                        states = ChildStatesBFS(alpha);
                        break;
                    }
            }
        }
        private List<State> ChildStatesDSF(State parentState)
        {
            List<Int16> unvisitedCities = FilterUnvisitedCities(parentState.path, AllCities);
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
                    child.AddCityToPath(AllCities[c]);
                    if (Input.Visualize)
                    {
                        drawingBoard.DrawPath(child, AllCities);
                        Thread.Sleep(200);
                    }
                    child.Cost += City.TravelCostBetweenCities(AllCities[child.path.Count - 2], AllCities[c]);
                    List<State> tmp = ChildStatesDSF(child);
                    foreach (State s in tmp)
                    {
                        childStates.Add(s);
                    }
                }
                return childStates;
            }
        }
        private List<State> ChildStatesBFS(State parentState)
        {
            List<Int16> unvisitedCities = FilterUnvisitedCities(parentState.path, AllCities);
            List<State> childStates = new List<State>();
            if (unvisitedCities.Count == 0)
            {
                return ReturnBottomChild(parentState, childStates);
            }
            else
            {
                List<State> subStates = new List<State>();
                foreach(Int16 c in unvisitedCities)
                {
                    subStates.Add((State)State.DeepClone(parentState));
                    subStates[subStates.Count - 1].AddCityToPath(AllCities[c]);
                    if (Input.Visualize)
                    {
                        drawingBoard.DrawPath(subStates[subStates.Count - 1], AllCities);
                        Thread.Sleep(1000);
                    }
                    subStates[subStates.Count - 1].Cost += City.TravelCostBetweenCities(AllCities[subStates[subStates.Count - 1].path.Count - 2], AllCities[c]);
                }
                /*foreach(State s in subStates)
                {
                    List<State> tmp = ChildStatesBFS(s);
                    foreach (State t in tmp)
                    {
                        childStates.Add(t);
                    }
                }*/
                return childStates;
            }
        }
        private static List<Int16> FilterUnvisitedCities(List<Int16> filter, List<City> cities)
        {
            List<Int16> unvisitedCities = new List<Int16>();
            foreach (City c in cities)
            {
                unvisitedCities.Add((Int16)c.Nr);
            }
            foreach (Int16 f in filter)
            {
                unvisitedCities.Remove(unvisitedCities.Single(s => s == f));
            }
            return unvisitedCities;
        }
        private List<State> ReturnBottomChild(State parentState, List<State> childStates)
        {
            if (Input.ReturnToStart)
            {
                parentState.AddCityToPath(AllCities[0]);
                parentState.Cost += City.TravelCostBetweenCities(AllCities[parentState.path.Count - 2], AllCities[0]);
            }
            childStates.Add(parentState);
            return childStates;
        }
        public void RandomizeLocations()
        {
            Random rnd = new Random();
            for (int i = 0; i < Input.Amount; i++)
            {
                path.Add((Int16)i);
                String cName = "city" + i;
                AllCities.Add(new City(rnd.Next(1, 350), rnd.Next(1, 350), i, cName));
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

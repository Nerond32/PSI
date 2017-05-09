using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TSP.TSPSolvers;

namespace TSP
{
    class Search
    {
        public enum Algorithm
        {
            BruteForceDSF,
            BruteForceBSF,
            GreedyAlgorithm,
            GeneticAlgorithm
        };
        public List<State> states = new List<State>();
        public SearchParameter SearchInfo { get; set; }
        private TSPAlgorithm tspAlg;
        private int method;
        private DrawingBoard DrawingBoard { get; set; }
        private List<Int16> path = new List<Int16>();
        public Search(DrawingBoard drawingBoard, SearchParameter Input, int method)
        {
            SearchInfo = Input;
            DrawingBoard = drawingBoard;
            Input.AllCities = new List<City>();
            this.method = method;
        }
        public void Start()
        {
            RandomizeLocations();
            State alpha = new State();
            alpha.AddCityToPath(SearchInfo.AllCities[0]);
            switch ((Algorithm)method)
            {
                case Algorithm.BruteForceDSF:
                    {
                        tspAlg = new BruteForceDFS_TSPAlgorithm(SearchInfo, DrawingBoard);
                        break;
                    }
                case Algorithm.BruteForceBSF:
                    {
                        tspAlg = new BruteForceBFS_TSPAlgorithm(SearchInfo, DrawingBoard);
                        break;
                    }
                case Algorithm.GreedyAlgorithm:
                    {
                        tspAlg = new TSPGreedyAlgorithm(SearchInfo, DrawingBoard);
                        break;
                    }
                case Algorithm.GeneticAlgorithm:
                    {
                        tspAlg = new TSPGeneticAlgorithm(SearchInfo, DrawingBoard);
                        break;
                    }
            }
            states = tspAlg.ChildStates(alpha);
        }
        public void RandomizeLocations()
        {
            Random rnd = new Random();
            for (int i = 0; i < SearchInfo.Amount; i++)
            {
                path.Add((Int16)i);
                String cName = "city" + i;
                SearchInfo.AllCities.Add(new City(rnd.Next(1, 350), rnd.Next(1, 350), i, cName));
            }
        }
        public void Sort(int criteria)
        {
            states = State.Sort(states, criteria);
        }
        
    }
}

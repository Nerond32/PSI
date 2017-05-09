using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSP.TSPSolvers
{
    class TSPGeneticAlgorithm : TSPAlgorithm
    {
        protected static readonly float rejectedPopulation = 0.25f;
        protected static readonly float similarityMargin = 0.1f;
        protected bool tooSimilar = false;
        protected List<State> population = new List<State>();
        protected List<State> nextGeneration = new List<State>();
        protected Random rnd = new Random();
        public TSPGeneticAlgorithm(SearchParameter searchInfo, DrawingBoard drawingBoard) : base(searchInfo, drawingBoard)
        {
        }

        public override List<State> ChildStates(State parentState)
        {
            GenerateRandomPopulation();
            foreach(State s in population)
            {
                s.Cost = CalculateAdaptation(s);
            }
            for (int i = 0; i < SearchInfo.NumberOfGenerations; i++) {
                Program.tspWindow.MessageReported("Generation " + i);
                population = State.Sort(population, 1);
                if (nextGeneration.Count != 0) {
                    population = nextGeneration;
                }
                nextGeneration = new List<State>();
                if ((population[0].Cost - population[population.Count-1].Cost)/population[0].Cost < similarityMargin)
                {
                    tooSimilar = true;
                }
                else
                {
                    tooSimilar = false;
                }
                for (int j = SearchInfo.Population - 1; j < population.Count - 1; j++)
                    {
                        population.RemoveAt(j);
                    }
                foreach (State p in population)
                {
                    if (SearchInfo.Visualize)
                    {
                        DrawingBoard.DrawPath(p, SearchInfo.AllCities);
                        Thread.Sleep(100);
                    }
                }
                for (int j = 0; j < SearchInfo.Population; j++)
                {
                    State parent1 = GetRandomParent(population);
                    State parent2 = GetRandomParent(population);
                    nextGeneration.Add(Multiply(parent1, parent2));
                }
                population.AddRange(nextGeneration);
            }
            return population;
        }
        protected State Multiply(State father, State mother)
        {
            State child = new State();
            child.path.Add(0);
            Int16 firstFatherGene = (Int16)rnd.Next(1, father.path.Count - 1);
            Int16 lastFatherGene = (Int16)rnd.Next(firstFatherGene, father.path.Count - 1);
            List<Int16> fatherGenes = father.path.GetRange(firstFatherGene, lastFatherGene - firstFatherGene + 1);
            fatherGenes.Add(0);
            Queue<Int16> motherGenes = new Queue<Int16>(FilterUnvisitedCities(fatherGenes, SearchInfo.AllCities));
            List<Int16> tmpMotherGenes = new List<Int16>(motherGenes);
            fatherGenes.RemoveAt(fatherGenes.Count - 1);
            for(int i = 1; i < SearchInfo.AllCities.Count; i++)
            {
                if (i >= firstFatherGene && i <= lastFatherGene)
                {
                    child.path.Add(fatherGenes[i-firstFatherGene]);
                }
                else
                {
                    child.path.Add(motherGenes.Dequeue());
                }
            }
            child.path.Add(0);
            child = Mutate(child);
            child.Cost = CalculateAdaptation(child);
            return child;
        }
        protected State Mutate(State s)
        {
            if (SearchInfo.MutationChance > rnd.Next(0, 100))
            {
                SwapGenes(s);
            }
            return s;
        }
        protected void SwapGenes(State s)
        {
            int g1 = rnd.Next(1, s.path.Count - 1);
            int g2 = rnd.Next(1, s.path.Count - 1);
            int tmp = s.path[g1];
            s.path[g1] = s.path[g2];
            s.path[g2] = (Int16)tmp;
        }
        protected State GetRandomParent(List<State> parents)
        {
            State parent = null;
            if (tooSimilar)
            {
                parent = parents[rnd.Next(0, parents.Count - 1)];
            }
            else
            {
                double sum = 0;
                foreach (State s in parents)
                {
                    sum += s.Cost;
                }
                double roulette = 0;
                while (parent == null)
                {
                    roulette = GetRandomNumber(0, sum);
                    double cost = 0.0;
                    foreach (State s in parents)
                    {
                        cost += s.Cost;
                        if (roulette > cost)
                        {
                            parent = s;
                        }
                    }
                }
            }
            return parent;
        }
        protected double GetRandomNumber(double minimum, double maximum)
        {
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }
        protected double CalculateAdaptation(State specimen)
        {
            double adaptation = 0.0;
            for(int i = 1; i < SearchInfo.Amount; i++)
            {
                adaptation += City.TravelCostBetweenCities(SearchInfo.AllCities[(specimen.path[i - 1])], SearchInfo.AllCities[(specimen.path[i])]);
            }
            return adaptation;
        }
        protected void GenerateRandomPopulation()
        {
            for(int i = 0; i < SearchInfo.Population; i++)
            {
                population.Add(CreateRandomSpecimen());
            }
        }
        protected State CreateRandomSpecimen()
        {
            State s = new State();
            s.AddCityToPath(SearchInfo.AllCities[0]);
            for(int i = 0; i < SearchInfo.Amount - 1; i++)
            {
                s.AddCityToPath(SearchInfo.AllCities[GetRandomCityFromList(FilterUnvisitedCities(s.path, SearchInfo.AllCities))]);
            }
            s.AddCityToPath(SearchInfo.AllCities[0]);
            return s;
        }
        protected Int16 GetRandomCityFromList(List<Int16> cities)
        {
            return cities[rnd.Next(0,cities.Count - 1)];
        }
    }
}

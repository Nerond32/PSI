using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP
{
    class Program
    {
        private static DrawingBoard f;
        private static Search tsp;
        private static readonly int cityAmount = 5;
        [STAThread]
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(StartDrawingBoard));
            t.Start();
            Thread.Sleep(200);
            tsp = new Search(cityAmount, f);
            tsp.Start();
            tsp.Sort(1);
            PrintOptimalPath(tsp.states[0]);
            Console.ReadKey();
        }
        private static void PrintOptimalPath(State s)
        {
            Console.WriteLine("Optimal path:");
            foreach (City c in s.path)
            {
                Console.Write("{0}, ", c.Name);
            }
            Console.WriteLine("\nCost - {0}", s.Cost);
            f.DrawPath(tsp.states[0], tsp.AllCities);
        }
        private static void StartDrawingBoard()
        {
            f = new DrawingBoard();
            Application.Run(f);
        }
       
    }
}
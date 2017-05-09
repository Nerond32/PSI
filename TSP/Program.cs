using System;
using System.Threading;
using System.Windows.Forms;

namespace TSP
{
    class Program
    {
        public static TSPWindow tspWindow;
        private static DrawingBoard drawingBoard;
        private static Search tsp;
        [STAThread]
        static void Main(string[] args)
        {
            StartDrawingBoard();
            Thread.Sleep(200);
        }
        public static void Start(SearchParameter input, int method)
        {
            tsp = new Search(drawingBoard, input, method);
            tsp.Start();
            tsp.Sort(1);
            drawingBoard.DrawPath(tsp.states[0], tsp.SearchInfo.AllCities);
            PrintOptimalPath(tsp.states[0]);
        }
        private static void PrintOptimalPath(State s)
        {
            String msg = "";
            msg += "Optimal path:";
            foreach (int c in s.path)
            {
                msg += " " + tsp.SearchInfo.AllCities[c].Name;
            }
            msg += "\nCost - " + s.Cost;
            msg += "\nMemory used at the end : " + (System.Diagnostics.Process.GetCurrentProcess().WorkingSet64/(1024*1024)) + "MB";
            drawingBoard.DrawPath(tsp.states[0], tsp.SearchInfo.AllCities);
            tspWindow.MessageReported(msg);
            tsp = null;
            GC.Collect();
        }
        private static void StartDrawingBoard()
        {
            drawingBoard = new DrawingBoard();
            tspWindow = new TSPWindow(drawingBoard);
            Application.Run(tspWindow);
        }
       
    }
}
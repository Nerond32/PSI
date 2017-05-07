using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TSP
{
    public class DrawingBoard : UserControl
    {
        public DrawingBoard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private void InitializeComponent()
        {
            ClientSize = new Size(400, 400);
            Text = "TSP Visualized";
        }
        public void DrawPath(State s, List<City> cities)
        {
            try
            {
                Graphics g = this.CreateGraphics();
                g.Clear(Color.White);
                g.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
                foreach (City c in cities)
                {
                    int rectSize = 9;
                    Font drawFont = new Font("Arial", 12);
                    g.DrawString(c.Name, drawFont, Brushes.Red, c.Pos.X - rectSize / 2, c.Pos.Y - rectSize * 3);
                    g.FillRectangle(Brushes.Red, c.Pos.X - rectSize / 2, c.Pos.Y - rectSize / 2, rectSize, rectSize);
                }
                Pen p = new Pen(Color.Black, 4);
                p.EndCap = LineCap.ArrowAnchor;
                for (int i = 1; i < s.path.Count; i++)
                {
                    g.DrawLine(p, cities[s.path[i - 1]].Pos.X, cities[s.path[i - 1]].Pos.Y, cities[s.path[i]].Pos.X, cities[s.path[i]].Pos.Y);
                }
            }
            catch (Exception e)
            {
                Environment.Exit(1);
            }
        }
    }
}

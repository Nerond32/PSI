using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP
{
    class DrawingBoard : Form
    {
        public DrawingBoard()
        {
            InitializeComponent();
            CenterToScreen();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private void InitializeComponent()
        {
            ClientSize = new Size(500, 500);
            Text = "TSP Visualized";
        }
        public void DrawPath(State s, List<City> cities)
        {
            try
            {
                Graphics g = this.CreateGraphics();
                g.Clear(Color.White);
                Pen p = new Pen(Color.Black, 4);
                p.EndCap = LineCap.ArrowAnchor;
                foreach (City c in cities)
                {
                    int rectSize = 9;
                    Font drawFont = new Font("Arial", 12);
                    g.DrawString(c.Name, drawFont, Brushes.Red, c.Pos.X - rectSize / 2, c.Pos.Y - rectSize * 3);
                    g.FillRectangle(Brushes.Red, c.Pos.X - rectSize / 2, c.Pos.Y - rectSize / 2, rectSize, rectSize);
                }
                for (int i = 1; i < s.path.Count; i++)
                {
                    g.DrawLine(p, s.path[i - 1].Pos.X, s.path[i - 1].Pos.Y, s.path[i].Pos.X, s.path[i].Pos.Y);
                }
            }
            catch (Exception e)
            {
                Environment.Exit(1);
            }
        }
    }
}

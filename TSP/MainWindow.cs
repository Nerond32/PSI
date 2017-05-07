using System;
using System.Threading;
using System.Windows.Forms;

namespace TSP
{
    public partial class TSPWindow : Form
    {
        private static DrawingBoard drawingBoard;
        private Thread searcher;
        public TSPWindow(DrawingBoard drawingBoard)
        {
            InitializeComponent();
            TSPWindow.drawingBoard = drawingBoard;
            algorithmComboBox.DataSource = Enum.GetValues(typeof(Search.Algorithm));
            drawingBoard.Visible = true;
            returnToStartCheckBox.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            splitContainer1.Panel2.Controls.Add(drawingBoard);
            drawingBoard.Show();
            InitHandlers();
        }
        private void InitHandlers()
        {
            startButton.Click += new EventHandler(this.start_Click);
            abortButton.Click += new EventHandler(this.abort_Click);
            citiesAmountInput.KeyPress += new KeyPressEventHandler(this.citiesAmountInput_KeyPress);
        }
        private void TSPWindow_Load(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void start_Click(object sender, EventArgs e)
        {
            SearchParameter input = new SearchParameter();
            String s = citiesAmountInput.Text;
            try
            {
                searcher.Abort();
            }
            catch(NullReferenceException ex)
            {

            }
            try
            {
                input.Amount = Int32.Parse(s);
                if (input.Amount > 1)
                {
                    input.Visualize = visualizeCheckBox.Checked;
                    input.ReturnToStart = returnToStartCheckBox.Checked;
                    input.Method = algorithmComboBox.SelectedIndex;
                    searcher = new Thread(() => Program.Start(input));
                    searcher.Start();
                }
                msgLabel.Text = "";
            }
            catch(Exception ex)
            {
                msgLabel.Text = "Invalid city amount. Must be a number greater than 1";
            }
        }
        delegate void SetTextCallback(string text);
        public void MessageReported(String s)
        {
            if (this.msgLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(MessageReported);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                this.msgLabel.Text = s;
            }
        }
        void abort_Click(object sender, EventArgs e)
        {
            if (searcher != null)
            {
                searcher.Abort();
            }
        }
        private void citiesAmountInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

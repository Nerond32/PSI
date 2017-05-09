using System;
using System.Globalization;
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
            isMutatingCheckBox.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            splitContainer1.Panel2.Controls.Add(drawingBoard);
            ShowOrHideGeneticSettings(false);
            drawingBoard.Show();
            InitHandlers();
        }
        private void InitHandlers()
        {
            startButton.Click += new EventHandler(this.start_Click);
            abortButton.Click += new EventHandler(this.abort_Click);
            algorithmComboBox.SelectedIndexChanged += new EventHandler(this.ShowOrHideAlgorithmSettings);
            citiesAmountInput.KeyPress += new KeyPressEventHandler(this.numberOnlyTextField_KeyPress);
            populationTextBox.KeyPress += new KeyPressEventHandler(this.numberOnlyTextField_KeyPress);
            generationsTextBox.KeyPress += new KeyPressEventHandler(this.numberOnlyTextField_KeyPress);
            mutationChanceTextBox.KeyPress += new KeyPressEventHandler(this.numberOnlyTextFieldWithDot_KeyPress);
        }
        private void ShowOrHideAlgorithmSettings(object sender, EventArgs e)
        {
            if((Search.Algorithm)algorithmComboBox.SelectedItem == Search.Algorithm.GeneticAlgorithm)
            {
                ShowOrHideGeneticSettings(true);
            }
            else
            {
                ShowOrHideGeneticSettings(false);
            }
        }
        private void ShowOrHideGeneticSettings(bool show)
        {
            isMutatingCheckBox.Visible = show;
            labelMutationChance.Visible = show;
            generationsLabel.Visible = show;
            populationLabel.Visible = show;
            mutationChanceTextBox.Visible = show;
            populationTextBox.Visible = show;
            generationsTextBox.Visible = show;
        }
        private SearchParameter AddGeneticSettings(SearchParameter s)
        {
            s.IsMutating = isMutatingCheckBox.Checked;
            if (s.IsMutating == true)
            {
                s.MutationChance = float.Parse(mutationChanceTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                if(s.MutationChance > 100.0f)
                {
                    s.MutationChance = 100.0f;
                    mutationChanceTextBox.Text = s.MutationChance.ToString();
                }
            }
            s.NumberOfGenerations = Int32.Parse(generationsTextBox.Text);
            s.Population = Int32.Parse(populationTextBox.Text);
            return s;
        }
        private void TSPWindow_Load(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void start_Click(object sender, EventArgs e)
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
                    if ((Search.Algorithm)algorithmComboBox.SelectedItem == Search.Algorithm.GeneticAlgorithm)
                    {
                        input = AddGeneticSettings(input);
                    }
                    input.Visualize = visualizeCheckBox.Checked;
                    input.ReturnToStart = returnToStartCheckBox.Checked;
                    int method = algorithmComboBox.SelectedIndex;
                    searcher = new Thread(() => Program.Start(input, method));
                    searcher.Start();
                }
                msgLabel.Text = "";
            }
            catch(Exception ex)
            {
                msgLabel.Text = "Invalid input parameters provided.";
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
        private void abort_Click(object sender, EventArgs e)
        {
            if (searcher != null)
            {
                searcher.Abort();
            }
            GC.Collect();
        }
        private void numberOnlyTextField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void numberOnlyTextFieldWithDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

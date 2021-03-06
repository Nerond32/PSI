﻿namespace TSP
{
    partial class TSPWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSPWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.returnToStartCheckBox = new System.Windows.Forms.CheckBox();
            this.abortButton = new System.Windows.Forms.Button();
            this.visualizeCheckBox = new System.Windows.Forms.CheckBox();
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.algLabel = new System.Windows.Forms.Label();
            this.cAmountLabel = new System.Windows.Forms.Label();
            this.citiesAmountInput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.populationTextBox = new System.Windows.Forms.TextBox();
            this.generationsTextBox = new System.Windows.Forms.TextBox();
            this.labelMutationChance = new System.Windows.Forms.Label();
            this.populationLabel = new System.Windows.Forms.Label();
            this.generationsLabel = new System.Windows.Forms.Label();
            this.mutationChanceTextBox = new System.Windows.Forms.TextBox();
            this.isMutatingCheckBox = new System.Windows.Forms.CheckBox();
            this.msgLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.returnToStartCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.abortButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.visualizeCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.algorithmComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.algLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cAmountLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.citiesAmountInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // returnToStartCheckBox
            // 
            resources.ApplyResources(this.returnToStartCheckBox, "returnToStartCheckBox");
            this.returnToStartCheckBox.Name = "returnToStartCheckBox";
            this.returnToStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // abortButton
            // 
            resources.ApplyResources(this.abortButton, "abortButton");
            this.abortButton.Name = "abortButton";
            this.abortButton.UseVisualStyleBackColor = true;
            // 
            // visualizeCheckBox
            // 
            resources.ApplyResources(this.visualizeCheckBox, "visualizeCheckBox");
            this.visualizeCheckBox.Name = "visualizeCheckBox";
            this.visualizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // algorithmComboBox
            // 
            resources.ApplyResources(this.algorithmComboBox, "algorithmComboBox");
            this.algorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Name = "algorithmComboBox";
            // 
            // algLabel
            // 
            resources.ApplyResources(this.algLabel, "algLabel");
            this.algLabel.Name = "algLabel";
            // 
            // cAmountLabel
            // 
            resources.ApplyResources(this.cAmountLabel, "cAmountLabel");
            this.cAmountLabel.Name = "cAmountLabel";
            // 
            // citiesAmountInput
            // 
            resources.ApplyResources(this.citiesAmountInput, "citiesAmountInput");
            this.citiesAmountInput.Name = "citiesAmountInput";
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.populationTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.generationsTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.labelMutationChance);
            this.splitContainer1.Panel1.Controls.Add(this.populationLabel);
            this.splitContainer1.Panel1.Controls.Add(this.generationsLabel);
            this.splitContainer1.Panel1.Controls.Add(this.mutationChanceTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.isMutatingCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.msgLabel);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // populationTextBox
            // 
            resources.ApplyResources(this.populationTextBox, "populationTextBox");
            this.populationTextBox.Name = "populationTextBox";
            // 
            // generationsTextBox
            // 
            resources.ApplyResources(this.generationsTextBox, "generationsTextBox");
            this.generationsTextBox.Name = "generationsTextBox";
            // 
            // labelMutationChance
            // 
            resources.ApplyResources(this.labelMutationChance, "labelMutationChance");
            this.labelMutationChance.Name = "labelMutationChance";
            // 
            // populationLabel
            // 
            resources.ApplyResources(this.populationLabel, "populationLabel");
            this.populationLabel.Name = "populationLabel";
            // 
            // generationsLabel
            // 
            resources.ApplyResources(this.generationsLabel, "generationsLabel");
            this.generationsLabel.Name = "generationsLabel";
            // 
            // mutationChanceTextBox
            // 
            resources.ApplyResources(this.mutationChanceTextBox, "mutationChanceTextBox");
            this.mutationChanceTextBox.Name = "mutationChanceTextBox";
            // 
            // isMutatingCheckBox
            // 
            resources.ApplyResources(this.isMutatingCheckBox, "isMutatingCheckBox");
            this.isMutatingCheckBox.Name = "isMutatingCheckBox";
            this.isMutatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // msgLabel
            // 
            resources.ApplyResources(this.msgLabel, "msgLabel");
            this.msgLabel.Name = "msgLabel";
            // 
            // TSPWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TSPWindow";
            this.Load += new System.EventHandler(this.TSPWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Label algLabel;
        private System.Windows.Forms.Label cAmountLabel;
        private System.Windows.Forms.TextBox citiesAmountInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox visualizeCheckBox;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.CheckBox returnToStartCheckBox;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.Label generationsLabel;
        private System.Windows.Forms.TextBox mutationChanceTextBox;
        private System.Windows.Forms.CheckBox isMutatingCheckBox;
        private System.Windows.Forms.TextBox populationTextBox;
        private System.Windows.Forms.TextBox generationsTextBox;
        private System.Windows.Forms.Label labelMutationChance;
    }
}
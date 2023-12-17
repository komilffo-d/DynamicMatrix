﻿namespace DynamicMatrix_WF
{
    partial class ResultForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            ResultDataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            fileTXTToolStripMenuItem = new ToolStripMenuItem();
            fileWordToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)ResultDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(234, 66);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Результат";
            // 
            // ResultDataGridView
            // 
            ResultDataGridView.AllowUserToAddRows = false;
            ResultDataGridView.AllowUserToDeleteRows = false;
            ResultDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 6.75F, FontStyle.Italic, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ResultDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ResultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultDataGridView.Location = new Point(29, 32);
            ResultDataGridView.Name = "ResultDataGridView";
            ResultDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 6.75F, FontStyle.Italic, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ResultDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ResultDataGridView.RowTemplate.Height = 25;
            ResultDataGridView.Size = new Size(495, 226);
            ResultDataGridView.TabIndex = 1;
            ResultDataGridView.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Enabled = false;
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(591, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.Visible = false;
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fileTXTToolStripMenuItem, fileWordToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(64, 20);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // fileTXTToolStripMenuItem
            // 
            fileTXTToolStripMenuItem.Name = "fileTXTToolStripMenuItem";
            fileTXTToolStripMenuItem.Size = new Size(135, 22);
            fileTXTToolStripMenuItem.Text = "TXT Файл";
            fileTXTToolStripMenuItem.Click += fileTXTToolStripMenuItem_Click;
            // 
            // fileWordToolStripMenuItem
            // 
            fileWordToolStripMenuItem.Name = "fileWordToolStripMenuItem";
            fileWordToolStripMenuItem.Size = new Size(135, 22);
            fileWordToolStripMenuItem.Text = "Word Файл";
            fileWordToolStripMenuItem.Click += fileWordToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(561, 270);
            label2.TabIndex = 3;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Visible = false;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 270);
            Controls.Add(ResultDataGridView);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ResultForm";
            Text = "Результат Формы";
            ((System.ComponentModel.ISupportInitialize)ResultDataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView ResultDataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem экспортToolStripMenuItem;
        private ToolStripMenuItem fileTXTToolStripMenuItem;
        private ToolStripMenuItem fileWordToolStripMenuItem;
        private Label label2;
    }
}
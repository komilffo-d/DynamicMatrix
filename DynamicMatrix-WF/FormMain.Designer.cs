namespace DynamicMatrix_WF
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MatrixOneDataDridView = new DataGridView();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            MatrixTwoDataDridView = new DataGridView();
            radioButton1 = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            groupBox2 = new GroupBox();
            matrixTwoGroupBox = new GroupBox();
            label3 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)MatrixOneDataDridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MatrixTwoDataDridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            matrixTwoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // MatrixOneDataDridView
            // 
            MatrixOneDataDridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MatrixOneDataDridView.Location = new Point(10, 130);
            MatrixOneDataDridView.Name = "MatrixOneDataDridView";
            MatrixOneDataDridView.RowTemplate.Height = 25;
            MatrixOneDataDridView.Size = new Size(480, 270);
            MatrixOneDataDridView.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(108, 26);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(48, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(108, 62);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(48, 23);
            numericUpDown2.TabIndex = 2;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 28);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Строки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 62);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Столбцы";
            // 
            // MatrixTwoDataDridView
            // 
            MatrixTwoDataDridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MatrixTwoDataDridView.Location = new Point(253, 130);
            MatrixTwoDataDridView.Name = "MatrixTwoDataDridView";
            MatrixTwoDataDridView.RowTemplate.Height = 25;
            MatrixTwoDataDridView.Size = new Size(480, 270);
            MatrixTwoDataDridView.TabIndex = 5;
            MatrixTwoDataDridView.Visible = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(33, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(103, 19);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "Одна матрица";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(24, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тип операций";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(33, 60);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(98, 19);
            radioButton2.TabIndex = 7;
            radioButton2.Text = "Две матрицы";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(numericUpDown2);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(253, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Матрица #1";
            // 
            // matrixTwoGroupBox
            // 
            matrixTwoGroupBox.Controls.Add(label3);
            matrixTwoGroupBox.Controls.Add(numericUpDown3);
            matrixTwoGroupBox.Controls.Add(numericUpDown4);
            matrixTwoGroupBox.Controls.Add(label4);
            matrixTwoGroupBox.Location = new Point(479, 12);
            matrixTwoGroupBox.Name = "matrixTwoGroupBox";
            matrixTwoGroupBox.Size = new Size(200, 100);
            matrixTwoGroupBox.TabIndex = 9;
            matrixTwoGroupBox.TabStop = false;
            matrixTwoGroupBox.Text = "Матрица #2";
            matrixTwoGroupBox.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 28);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 3;
            label3.Text = "Строки";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(108, 26);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(48, 23);
            numericUpDown3.TabIndex = 1;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(108, 62);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(48, 23);
            numericUpDown4.TabIndex = 2;
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 62);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 4;
            label4.Text = "Столбцы";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 489);
            Controls.Add(matrixTwoGroupBox);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(MatrixTwoDataDridView);
            Controls.Add(MatrixOneDataDridView);
            Name = "FormMain";
            Text = "Form1";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)MatrixOneDataDridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)MatrixTwoDataDridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            matrixTwoGroupBox.ResumeLayout(false);
            matrixTwoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView MatrixOneDataDridView;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label1;
        private Label label2;
        private DataGridView MatrixTwoDataDridView;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private GroupBox groupBox2;
        private GroupBox matrixTwoGroupBox;
        private Label label3;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private Label label4;
    }
}

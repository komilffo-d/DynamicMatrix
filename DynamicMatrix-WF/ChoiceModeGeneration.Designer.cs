namespace DynamicMatrix_WF
{
    partial class ChoiceModeGeneration
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
            groupBox1 = new GroupBox();
            Both = new RadioButton();
            Right = new RadioButton();
            Left = new RadioButton();
            label1 = new Label();
            ok_button = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Both);
            groupBox1.Controls.Add(Right);
            groupBox1.Controls.Add(Left);
            groupBox1.Location = new Point(55, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 93);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Режим";
            // 
            // Both
            // 
            Both.AutoSize = true;
            Both.Location = new Point(217, 38);
            Both.Name = "Both";
            Both.Size = new Size(47, 19);
            Both.TabIndex = 2;
            Both.Text = "Обе";
            Both.UseVisualStyleBackColor = true;
            // 
            // Right
            // 
            Right.AutoSize = true;
            Right.Location = new Point(130, 38);
            Right.Name = "Right";
            Right.Size = new Size(65, 19);
            Right.TabIndex = 1;
            Right.Text = "Правая";
            Right.UseVisualStyleBackColor = true;
            // 
            // Left
            // 
            Left.AutoSize = true;
            Left.Checked = true;
            Left.Location = new Point(47, 38);
            Left.Name = "Left";
            Left.Size = new Size(57, 19);
            Left.TabIndex = 0;
            Left.TabStop = true;
            Left.Text = "Левая";
            Left.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 36);
            label1.Name = "label1";
            label1.Size = new Size(428, 20);
            label1.TabIndex = 1;
            label1.Text = "Выберите матрицы, для которых надо сгенерировать числа";
            // 
            // ok_button
            // 
            ok_button.Location = new Point(117, 186);
            ok_button.Name = "ok_button";
            ok_button.Size = new Size(182, 23);
            ok_button.TabIndex = 2;
            ok_button.Text = "ОК";
            ok_button.UseVisualStyleBackColor = true;
            ok_button.Click += ok_button_Click;
            // 
            // ChoiceModeGeneration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 233);
            Controls.Add(ok_button);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChoiceModeGeneration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChoiceModeGeneration";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton Both;
        private RadioButton Right;
        private RadioButton Left;
        private Label label1;
        private Button ok_button;
    }
}
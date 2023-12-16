using DynamicMatrix_DLL;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DynamicMatrix_WF
{
    public partial class FormMain : Form
    {
        public FormMain()
        {

            InitializeComponent();

            int rows = 3, cols = 3;
            int[,] arrayIn = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var ptr = DynamicMatrix.ConvertToFloatMatrix(in arrayIn, new nint((uint)rows), new nint((uint)cols));







           
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            RedrawMatrixOne();

        }
        private void RedrawMatrixOne()
        {
            DataTable table = new DataTable();

            for (int i = 0; i < numericUpDown2.Value; i++)
            {
                DataColumn column = new DataColumn((i + 1).ToString());

                table.Columns.Add(column);
            }
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                DataRow row = table.NewRow();

                table.Rows.Add(row);
            }

            MatrixOneDataDridView.DataSource = table;
            foreach (DataGridViewColumn column in MatrixOneDataDridView.Columns)

            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = false;
            }
            foreach (DataGridViewRow row in MatrixOneDataDridView.Rows)

                row.HeaderCell.Value = (row.Index + 1).ToString();

            MatrixOneDataDridView.Refresh();
        }
        private void RedrawMatrixTwo()
        {
            DataTable table = new DataTable();

            for (int i = 0; i < numericUpDown4.Value; i++)
            {
                DataColumn column = new DataColumn((i + 1).ToString());

                table.Columns.Add(column);
            }
            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                DataRow row = table.NewRow();

                table.Rows.Add(row);
            }

            MatrixTwoDataDridView.DataSource = table;
            foreach (DataGridViewColumn column in MatrixTwoDataDridView.Columns)

            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = false;
            }
            foreach (DataGridViewRow row in MatrixTwoDataDridView.Rows)

                row.HeaderCell.Value = (row.Index + 1).ToString();

            MatrixTwoDataDridView.Refresh();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RedrawMatrixOne();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)(sender);
            if (radioButton.Checked)
            {
                matrixTwoGroupBox.Visible = false;
                int offsetMatrix = 120;
                MatrixOneDataDridView.Width = MatrixTwoDataDridView.Width + offsetMatrix;
                MatrixTwoDataDridView.Width = MatrixTwoDataDridView.Width + offsetMatrix;
                MatrixTwoDataDridView.Location = new Point(MatrixTwoDataDridView.Location.X - offsetMatrix, 130);
                MatrixTwoDataDridView.Visible = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)(sender);
            if (radioButton.Checked)
            {
                matrixTwoGroupBox.Visible = true;
                int offsetMatrix = 120;

                MatrixOneDataDridView.Width = MatrixTwoDataDridView.Width - offsetMatrix;
                MatrixTwoDataDridView.Width = MatrixTwoDataDridView.Width - offsetMatrix;
                MatrixTwoDataDridView.Location = new Point(MatrixTwoDataDridView.Location.X + offsetMatrix, 130);
                MatrixTwoDataDridView.Visible = true;
            }


        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            RedrawMatrixTwo();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            RedrawMatrixTwo();
        }

    }
}

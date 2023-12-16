using DynamicMatrix_DLL;
using System.Data;
using System.Windows.Forms;

namespace DynamicMatrix_WF
{
    public partial class FormMain : Form
    {

        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
            public bool Selectable { get; set; }
        }

        public FormMain()
        {

            InitializeComponent();

            int rows = 3, cols = 3;
            int[,] arrayIn = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var ptr = DynamicMatrix.ConvertToFloatMatrix(in arrayIn, new nint((uint)rows), new nint((uint)cols));
            RedrawComboBox(false);







        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;


        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            RedrawMatrixOne();

        }
        private void RedrawComboBox(bool pairOperation = false)
        {
            comboBox1.Items.Clear();
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Text";
            if (pairOperation)
            {
                comboBox1.Items.AddRange(new[] {
                    new ComboBoxItem() { Selectable = true, Text="Суммирование матриц", Value=0},
                    new ComboBoxItem() { Selectable = true, Text="Вычитание матриц", Value=1},
                    new ComboBoxItem() { Selectable = true, Text="Перемножение матриц", Value=2},
                    new ComboBoxItem() { Selectable = false, Text="Умножение матрицы на число", Value=3},
                    new ComboBoxItem() { Selectable = true, Text="Деление матриц", Value=4},
                    new ComboBoxItem() { Selectable = false, Text="Нахождение определителя", Value=5},
                    new ComboBoxItem() { Selectable = false, Text="Транспонирование матрицы", Value=6},
                    new ComboBoxItem() { Selectable = false, Text="Нахождение обратной матрицы", Value=7},
            });
            }
            else
            {
                comboBox1.Items.AddRange(new[] {
                    new ComboBoxItem() { Selectable = false, Text="Суммирование матриц", Value=0},
                    new ComboBoxItem() { Selectable = false, Text="Вычитание матриц", Value=1},
                    new ComboBoxItem() { Selectable = false, Text="Перемножение матриц", Value=2},
                    new ComboBoxItem() { Selectable = true, Text="Умножение матрицы на число", Value=3},
                    new ComboBoxItem() { Selectable = false, Text="Деление матриц", Value=4},
                    new ComboBoxItem() { Selectable = true, Text="Нахождение определителя", Value=5},
                    new ComboBoxItem() { Selectable = true, Text="Транспонирование матрицы", Value=6},
                    new ComboBoxItem() { Selectable = true, Text="Нахождение обратной матрицы", Value=7},
            });
            }
            comboBox1.Refresh();

        }
        private void RedrawMatrixOne()
        {
            DataTable table = new DataTable();

            for (int i = 0; i < numericUpDown2.Value; i++)
            {
                DataColumn column = new DataColumn((i + 1).ToString());
                column.DefaultValue = 0;
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
                column.Width = 30;
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
                column.DefaultValue = 0;
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
                column.Width = 30;
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
                RedrawComboBox(false);
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
                RedrawComboBox(true);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;

            if (cb.SelectedItem != null && cb.SelectedItem is ComboBoxItem && ((ComboBoxItem)cb.SelectedItem).Selectable == false)
            {
                cb.SelectedIndex = -1;
            }

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var cb = sender as ComboBox;
            if (e.Index >= 0)
            {
                ComboBoxItem specificItem = (ComboBoxItem)cb.Items[e.Index];

                if (specificItem.Selectable == false)
                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                else
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.Graphics.DrawString(specificItem.Text, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            }
        }

        private void fileTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Матрица #1\n");
                    foreach (DataGridViewRow row in MatrixOneDataDridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sw.Write(cell.Value + "\t");
                        }
                        sw.WriteLine("");
                    }
                }
            }
        }
    }
}

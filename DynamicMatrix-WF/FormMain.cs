using DynamicMatrix_DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System.Data;
using DataTable = System.Data.DataTable;
using Point = System.Drawing.Point;
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
                    new ComboBoxItem() { Selectable = true, Text="������������ ������", Value=0},
                    new ComboBoxItem() { Selectable = true, Text="��������� ������", Value=1},
                    new ComboBoxItem() { Selectable = true, Text="������������ ������", Value=2},
                    new ComboBoxItem() { Selectable = false, Text="��������� ������� �� �����", Value=3},
                    new ComboBoxItem() { Selectable = true, Text="������� ������", Value=4},
                    new ComboBoxItem() { Selectable = false, Text="���������� ������������", Value=5},
                    new ComboBoxItem() { Selectable = false, Text="���������������� �������", Value=6},
                    new ComboBoxItem() { Selectable = false, Text="���������� �������� �������", Value=7},
            });
            }
            else
            {
                comboBox1.Items.AddRange(new[] {
                    new ComboBoxItem() { Selectable = false, Text="������������ ������", Value=0},
                    new ComboBoxItem() { Selectable = false, Text="��������� ������", Value=1},
                    new ComboBoxItem() { Selectable = false, Text="������������ ������", Value=2},
                    new ComboBoxItem() { Selectable = true, Text="��������� ������� �� �����", Value=3},
                    new ComboBoxItem() { Selectable = false, Text="������� ������", Value=4},
                    new ComboBoxItem() { Selectable = true, Text="���������� ������������", Value=5},
                    new ComboBoxItem() { Selectable = true, Text="���������������� �������", Value=6},
                    new ComboBoxItem() { Selectable = true, Text="���������� �������� �������", Value=7},
            });
            }
            comboBox1.Refresh();

        }
        private void RedrawMatrixOne(string[][]? valueMatrix = null)
        {
            if (valueMatrix is not null)
            {
                numericUpDown1.Value = valueMatrix.GetLength(0);
                numericUpDown2.Value = valueMatrix.Select(subArr => subArr.Count()).Sum() / valueMatrix.GetLength(0);
            }
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
            if (valueMatrix is not null)
            {
                foreach ((string[] row, int indexOut) in valueMatrix.Select((row, indexOut) => (row, indexOut)))
                {
                    foreach ((string cell, int indexIn) in row.Select((cell, indexIn) => (cell, indexIn)))
                    {
                        MatrixOneDataDridView.Rows[indexOut].Cells[indexIn].Value = cell;
                    }
                }
            }
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "��������� ����� (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("������� #1\n");
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

        private void fileWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word ��������� (*.docx)|*.docx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                Document doc = wordApp.Documents.Add();

                Table table = doc.Tables.Add(doc.Range(), MatrixOneDataDridView.Rows.Count + 1, MatrixOneDataDridView.ColumnCount);

                for (int i = 0; i < MatrixOneDataDridView.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = MatrixOneDataDridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < MatrixOneDataDridView.Rows.Count; i++)
                {
                    for (int j = 0; j < MatrixOneDataDridView.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = MatrixOneDataDridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                object fileName = saveFileDialog1.FileName;
                doc.SaveAs2(ref fileName);

                doc.Close();
                wordApp.Quit();

                MessageBox.Show("������ ������� �������� � ���� Word.", "������� � Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void fileTXTImportoolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "��������� ����� (*.txt)|*.txt";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int linesToSkip = 2;
                MatrixOneDataDridView.DataSource = null;
                MatrixOneDataDridView.Rows.Clear();

                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    for (int i = 0; i < linesToSkip; i++)
                        sr.ReadLine();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                string[][] matrixValue = new string[lines.Count][];
                foreach ((string line, int index) in lines.Select((string line, int index) => (line, index)))
                {

                    matrixValue[index] = line.Trim('\t').Split('\t');
                }
                RedrawMatrixOne(matrixValue);
            }
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            using (var dbContext = new AppDbContext())
            {
                Models.Action action = new Models.Action() { ActionType = ActionEnum.SumMatrices, Result = "13", };
                dbContext.Actions.Add(action);
                dbContext.SaveChanges();
            }
        }
    }
}

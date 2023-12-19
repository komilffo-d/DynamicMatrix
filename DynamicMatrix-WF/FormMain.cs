using DynamicMatrix_DLL;
using DynamicMatrix_WF.Models;
using Newtonsoft.Json;
using Syroot.Windows.IO;
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
                    new ComboBoxItem() { Selectable = true, Text="������������ ������", Value=1},
                    new ComboBoxItem() { Selectable = true, Text="��������� ������", Value=2},
                    new ComboBoxItem() { Selectable = true, Text="������������ ������", Value=3},
                    new ComboBoxItem() { Selectable = false, Text="��������� ������� �� �����", Value=4},
                    new ComboBoxItem() { Selectable = true, Text="������� ������", Value=5},
                    new ComboBoxItem() { Selectable = false, Text="���������� ������������", Value=6},
                    new ComboBoxItem() { Selectable = false, Text="���������������� �������", Value=7},
                    new ComboBoxItem() { Selectable = false, Text="���������� �������� �������", Value=8},
            });
            }
            else
            {
                comboBox1.Items.AddRange(new[] {
                    new ComboBoxItem() { Selectable = false, Text="������������ ������", Value=1},
                    new ComboBoxItem() { Selectable = false, Text="��������� ������", Value=2},
                    new ComboBoxItem() { Selectable = false, Text="������������ ������", Value=3},
                    new ComboBoxItem() { Selectable = true, Text="��������� ������� �� �����", Value=4},
                    new ComboBoxItem() { Selectable = false, Text="������� ������", Value=5},
                    new ComboBoxItem() { Selectable = true, Text="���������� ������������", Value=6},
                    new ComboBoxItem() { Selectable = true, Text="���������������� �������", Value=7},
                    new ComboBoxItem() { Selectable = true, Text="���������� �������� �������", Value=8},
            });
            }
            comboBox1.Refresh();

        }
        private void RedrawMatrixOne(string[][]? valueMatrix = null)
        {
            MatrixOneDataDridView.CellValueChanged -= MatrixOneDataDridView_CellValueChanged!;
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
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = false;
            }
            foreach (DataGridViewRow row in MatrixOneDataDridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();

            }


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
            MatrixOneDataDridView.CellValueChanged += MatrixOneDataDridView_CellValueChanged!;
        }
        private void RedrawMatrixTwo(string[][]? valueMatrix = null)
        {

            if (valueMatrix is not null)
            {
                numericUpDown3.Value = valueMatrix.GetLength(0);
                numericUpDown4.Value = valueMatrix.Select(subArr => subArr.Count()).Sum() / valueMatrix.GetLength(0);
            }
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
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = false;
            }
            foreach (DataGridViewRow row in MatrixTwoDataDridView.Rows)

                row.HeaderCell.Value = (row.Index + 1).ToString();
            if (valueMatrix is not null)
            {
                foreach ((string[] row, int indexOut) in valueMatrix.Select((row, indexOut) => (row, indexOut)))
                {
                    foreach ((string cell, int indexIn) in row.Select((cell, indexIn) => (cell, indexIn)))
                    {
                        MatrixTwoDataDridView.Rows[indexOut].Cells[indexIn].Value = cell;
                    }
                }
            }
            MatrixTwoDataDridView.Refresh();

        }
        private string[,] GetMatrixOne()
        {
            int rowsCount = MatrixOneDataDridView.RowCount;
            int colsCount = MatrixOneDataDridView.ColumnCount;
            string[,] values = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    values[i, j] = MatrixOneDataDridView.Rows[i].Cells[j].Value.ToString()!;
                }
            }
            return values;
        }
        private string[,] GetMatrixTwo()
        {
            int rowsCount = MatrixTwoDataDridView.RowCount;
            int colsCount = MatrixTwoDataDridView.ColumnCount;
            string[,] values = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    values[i, j] = MatrixTwoDataDridView.Rows[i].Cells[j].Value.ToString()!;
                }
            }
            return values;
        }
        private int[,] ConvertMatrixToInt(string[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[,] intArray = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    intArray[i, j] = int.Parse(matrix[i, j]);
                }
            }

            return intArray;
        }
        private float[,] ConvertMatrixToFloat(string[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            float[,] floatArray = new float[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    floatArray[i, j] = float.Parse(matrix[i, j]);
                }
            }

            return floatArray;
        }
        private string[,] ConvertMatrixToString<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            string[,] stringArray = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    stringArray[i, j] = matrix[i, j].ToString()!;
                }
            }

            return stringArray;
        }
        private bool checkMatrixFloat(string[,] matrix)
        {
            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);

            bool isFloat = default;
            for (int i = 0; i < rowsCount; i++)
            {
                if (isFloat)
                    break;
                for (int j = 0; j < colsCount; j++)
                {
                    string cellValue = matrix[i, j];
                    float result;
                    isFloat = float.TryParse(cellValue, out result) && (cellValue.Contains(".") || cellValue.Contains(","));

                    if (isFloat)
                        break;
                }
            }
            return isFloat;
        }

        private bool checkMatricesEqualityDestinationLength(string[,] matrixOne, string[,] matrixTwo)
        {
            int rows1 = matrixOne.GetLength(0);
            int columns1 = matrixOne.GetLength(1);

            int rows2 = matrixTwo.GetLength(0);
            int columns2 = matrixTwo.GetLength(1);

            return (rows1 == rows2) && (columns1 == columns2);
        }
        private bool checkMatricesEqualityMirrorDestinationLength(string[,] matrixOne, string[,] matrixTwo)
        {
            int columns1 = matrixOne.GetLength(1);

            int rows2 = matrixTwo.GetLength(0);

            return (columns1 == rows2);
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
                clearAllControls();
                RedrawComboBox(false);
                matrixTwoGroupBox.Visible = false;

                MatrixTwoDataDridView.Visible = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)(sender);
            if (radioButton.Checked)
            {
                clearAllControls();
                RedrawComboBox(true);
                matrixTwoGroupBox.Visible = true;
                MatrixTwoDataDridView.Visible = true;
            }


        }

        private void clearAllControls()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            RedrawComboBox();

            NumberLabel.Visible = false;
            NumberTextBox.Visible = false;
            NumberTextBox.Enabled = false;
            NumberTextBox.Clear();
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
                cb.SelectedIndex = -1;


            if (cb.SelectedItem != null && cb.SelectedItem is ComboBoxItem && ((ComboBoxItem)cb.SelectedItem).Text == "��������� ������� �� �����")
            {

                NumberLabel.Visible = true;
                NumberTextBox.Visible = true;
                NumberTextBox.Enabled = true;
                NumberTextBox.Clear();


            }
            else
            {
                NumberLabel.Visible = false;
                NumberTextBox.Visible = false;
                NumberTextBox.Enabled = false;
                NumberTextBox.Clear();
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
            saveFileDialog1.InitialDirectory = KnownFolders.Downloads.Path;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("/*** ������� #1 ***/\n");
                    foreach (DataGridViewRow row in MatrixOneDataDridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sw.Write(cell.Value + "\t");
                        }
                        sw.WriteLine("");
                    }
                    if (radioButton2.Checked)
                    {
                        sw.WriteLine("\n/*** ������� #2 ***/\n");
                        foreach (DataGridViewRow row in MatrixTwoDataDridView.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sw.Write(cell.Value + "\t");
                            }
                            sw.WriteLine("");
                        }
                    }

                }
                MessageBox.Show("������ ������� �������� � ���� TXT.", "������� � TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void fileTXTImportoolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "��������� ����� (*.txt)|*.txt";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = KnownFolders.Downloads.Path;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {


                int linesToSkip = 2;
                MatrixOneDataDridView.DataSource = null;
                MatrixOneDataDridView.Rows.Clear();

                List<string> linesOne = new List<string>();
                List<string> linesTwo = new List<string>();

                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    for (int i = 0; i < linesToSkip; i++)
                        sr.ReadLine();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length != 0)
                            linesOne.Add(line);
                        else
                            break;

                    }
                    for (int i = 0; i < linesToSkip; i++)
                        sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length != 0)
                            linesTwo.Add(line);
                        else
                            break;
                    }
                }

                string[][] matrixOneValue = new string[linesOne.Count][], matrixTwoValue = new string[linesTwo.Count][];
                foreach ((string line, int index) in linesOne.Select((string line, int index) => (line, index)))
                    matrixOneValue[index] = line.Trim('\t').Split('\t');
                foreach ((string line, int index) in linesTwo.Select((string line, int index) => (line, index)))
                    matrixTwoValue[index] = line.Trim('\t').Split('\t');
                RedrawMatrixOne(matrixOneValue);
                if (matrixTwoValue.Length > 0 && radioButton2.Checked)
                    RedrawMatrixTwo(matrixTwoValue);
            }
        }

        private async void ActionButton_Click(object sender, EventArgs e)
        {

            using (var dbContext = new AppDbContext())
            {
                string[,] matrixOne = GetMatrixOne();
                string[,] matrixTwo = GetMatrixTwo();

                int[,] resultIntMatrix = default!;
                float[,] resultFloatMatrix = default!;

                int? resultInt = null;
                float? resultFloat = null;


                var cbItem = comboBox1.Invoke(new Func<object>(() => comboBox1.SelectedItem));


                if (cbItem is not null && Enum.IsDefined(typeof(ActionEnum), ((ComboBoxItem)cbItem).Value))
                {

                    switch ((ActionEnum)((ComboBoxItem)cbItem).Value)
                    {
                        case ActionEnum.SumMatrices when checkMatrixFloat(matrixOne) || checkMatrixFloat(matrixTwo):
                            if (checkMatricesEqualityDestinationLength(matrixOne, matrixTwo))
                                resultFloatMatrix = DynamicMatrix.AddMatrixFloat(ConvertMatrixToFloat(matrixOne), ConvertMatrixToFloat(matrixTwo), (nint)(matrixOne.GetLength(0) + matrixTwo.GetLength(0)) / 2, (nint)(matrixOne.GetLength(1) + matrixTwo.GetLength(1)) / 2);
                            else
                                MessageBox.Show("������� �� ��������� �� �������.");
                            break;
                        case ActionEnum.SumMatrices:
                            if (checkMatricesEqualityDestinationLength(matrixOne, matrixTwo))
                                resultIntMatrix = DynamicMatrix.AddMatrixInt(ConvertMatrixToInt(matrixOne), ConvertMatrixToInt(matrixTwo), (nint)(matrixOne.GetLength(0) + matrixTwo.GetLength(0)) / 2, (nint)(matrixOne.GetLength(1) + matrixTwo.GetLength(1)) / 2);
                            else
                                MessageBox.Show("������� �� ��������� �� �������.");
                            break;
                        case ActionEnum.SubtractMatrices when checkMatrixFloat(matrixOne) || checkMatrixFloat(matrixTwo):
                            if (checkMatricesEqualityDestinationLength(matrixOne, matrixTwo))
                                resultFloatMatrix = DynamicMatrix.SubtractMatricesFloat(ConvertMatrixToFloat(matrixOne), ConvertMatrixToFloat(matrixTwo), (nint)(matrixOne.GetLength(0) + matrixTwo.GetLength(0)) / 2, (nint)(matrixOne.GetLength(1) + matrixTwo.GetLength(1)) / 2);
                            else
                                MessageBox.Show("������� �� ��������� �� �������.");
                            break;
                        case ActionEnum.SubtractMatrices:
                            if (checkMatricesEqualityDestinationLength(matrixOne, matrixTwo))
                                resultIntMatrix = DynamicMatrix.SubtractMatricesInt(ConvertMatrixToInt(matrixOne), ConvertMatrixToInt(matrixTwo), (nint)(matrixOne.GetLength(0) + matrixTwo.GetLength(0)) / 2, (nint)(matrixOne.GetLength(1) + matrixTwo.GetLength(1)) / 2);
                            else
                                MessageBox.Show("������� �� ��������� �� �������.");
                            break;
                        case ActionEnum.MultiplyMatrices when checkMatrixFloat(matrixOne) || checkMatrixFloat(matrixTwo):
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixTwo))
                                resultFloatMatrix = DynamicMatrix.MultiplyMatricesFloat(ConvertMatrixToFloat(matrixOne), ConvertMatrixToFloat(matrixTwo), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), (nint)matrixTwo.GetLength(0), (nint)matrixTwo.GetLength(1));
                            else
                                MessageBox.Show("������� �� ��������� �� ������� ������������� ���������.");
                            break;
                        case ActionEnum.MultiplyMatrices:
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixTwo))
                                resultIntMatrix = DynamicMatrix.MultiplyMatricesInt(ConvertMatrixToInt(matrixOne), ConvertMatrixToInt(matrixTwo), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), (nint)matrixTwo.GetLength(0), (nint)matrixTwo.GetLength(1));
                            else
                                MessageBox.Show("������� �� ��������� �� ������� ������������� ���������.");
                            break;
                        case ActionEnum.MultiplicationMatrixOnNumber when checkMatrixFloat(matrixOne):

                            if (float.TryParse(NumberTextBox.Text, out float numberFloat))
                                resultFloatMatrix = DynamicMatrix.MultiplicationOnNumberFloat(ConvertMatrixToFloat(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), numberFloat);
                            else
                                MessageBox.Show("����� �� ������ ��� ����� �� ������ ������!");
                            break;
                        case ActionEnum.MultiplicationMatrixOnNumber:
                            if (int.TryParse(NumberTextBox.Text, out int numberInt))
                                resultIntMatrix = DynamicMatrix.MultiplicationOnNumberInt(ConvertMatrixToInt(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), numberInt);
                            else
                                MessageBox.Show("����� �� ������ ��� ����� �� ������ ������!");
                            break;
                        case ActionEnum.DivisionMatrix when checkMatrixFloat(matrixOne) || checkMatrixFloat(matrixTwo):
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixTwo))
                            {
                                resultFloatMatrix = DynamicMatrix.DivisionMatrixFloat(ConvertMatrixToFloat(matrixOne), ConvertMatrixToFloat(matrixTwo), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), (nint)matrixTwo.GetLength(0), (nint)matrixTwo.GetLength(1));
                                if (resultFloatMatrix is null)
                                {
                                    MessageBox.Show("������ ������� �������� �����������");
                                }
                            }
                                
                            else
                                MessageBox.Show("������� �� ��������� �� ������� ������������� ���������.");
                            break;
                        case ActionEnum.DivisionMatrix:
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixTwo))
                            {
                                resultFloatMatrix = DynamicMatrix.DivisionMatrixInt(ConvertMatrixToInt(matrixOne), ConvertMatrixToInt(matrixTwo), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1), (nint)matrixTwo.GetLength(0), (nint)matrixTwo.GetLength(1));
                                if (resultFloatMatrix is null)
                                {
                                    MessageBox.Show("������ ������� �������� �����������");
                                }
                            }

                            else
                                MessageBox.Show("������� �� ��������� �� ������� ������������� ���������.");
                            break;

                        case ActionEnum.DeterminantMatrix when checkMatrixFloat(matrixOne):
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixOne))
                                resultFloat = DynamicMatrix.DeterminantFloat(ConvertMatrixToFloat(matrixOne));
                            else
                                MessageBox.Show("������� �� �������� ����������");
                            break;
                        case ActionEnum.DeterminantMatrix:
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixOne))
                                resultInt = DynamicMatrix.DeterminantInt(ConvertMatrixToInt(matrixOne));
                            else
                                MessageBox.Show("������� �� �������� ����������.");
                            break;
                        case ActionEnum.TranspositionMatrix when checkMatrixFloat(matrixOne):
                            resultFloatMatrix = DynamicMatrix.Transposition<float>(ConvertMatrixToFloat(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1));

                            break;
                        case ActionEnum.TranspositionMatrix:
                            resultIntMatrix = DynamicMatrix.Transposition<int>(ConvertMatrixToInt(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1));

                            break;
                        case ActionEnum.ReverseMatrix when checkMatrixFloat(matrixOne):
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixOne) && DynamicMatrix.DeterminantFloat(ConvertMatrixToFloat(matrixOne)) != 0)
                                resultFloatMatrix = DynamicMatrix.ReverseMatrix<float>(ConvertMatrixToFloat(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1));
                            else
                                MessageBox.Show("������� �������� ����������� ��� ������������.");

                            break;
                        case ActionEnum.ReverseMatrix:
                            if (checkMatricesEqualityMirrorDestinationLength(matrixOne, matrixOne) && DynamicMatrix.DeterminantInt(ConvertMatrixToInt(matrixOne)) != 0)
                                resultFloatMatrix = DynamicMatrix.ReverseMatrix<int>(ConvertMatrixToInt(matrixOne), (nint)matrixOne.GetLength(0), (nint)matrixOne.GetLength(1));
                            else
                                MessageBox.Show("������� �������� ����������� ��� ������������.");


                            break;
                        default:
                            break;
                    }
                    if (resultIntMatrix is not null)
                    {
                        Models.Action action = new Models.Action() { ActionType = (ActionEnum)((ComboBoxItem)cbItem).Value, Result = JsonConvert.SerializeObject(resultIntMatrix), };
                        await dbContext.Actions.AddAsync(action);



                        Value entityOne = new Value() { Number = JsonConvert.SerializeObject(matrixOne), Action = action };

                        await dbContext.Values.AddAsync(entityOne);
                        if (matrixTwo.Length > 0)
                        {
                            Value entityTwo = new Value() { Number = JsonConvert.SerializeObject(matrixTwo), Action = action };

                            await dbContext.Values.AddAsync(entityTwo);
                        }



                        await dbContext.SaveChangesAsync();
                        ResultForm resultForm = new ResultForm(ConvertMatrixToString(resultIntMatrix), matrixOne, matrixTwo);

                        resultForm.Show();
                    }
                    if (resultFloatMatrix is not null)
                    {
                        Models.Action action = new Models.Action() { ActionType = (ActionEnum)((ComboBoxItem)cbItem).Value, Result = JsonConvert.SerializeObject(resultFloatMatrix), };
                        await dbContext.Actions.AddAsync(action);



                        Value entityOne = new Value() { Number = JsonConvert.SerializeObject(matrixOne), Action = action };

                        await dbContext.Values.AddAsync(entityOne);

                        if (matrixTwo.Length > 0)
                        {
                            Value entityTwo = new Value() { Number = JsonConvert.SerializeObject(matrixTwo), Action = action };

                            await dbContext.Values.AddAsync(entityTwo);
                        }


                        await dbContext.SaveChangesAsync();
                        ResultForm resultForm = new ResultForm(ConvertMatrixToString(resultFloatMatrix), matrixOne, matrixTwo);
                        resultForm.Show();
                    }
                    if (resultInt is not null)
                    {
                        Models.Action action = new Models.Action() { ActionType = (ActionEnum)((ComboBoxItem)cbItem).Value, Result = resultInt.ToString(), };
                        await dbContext.Actions.AddAsync(action);



                        Value entity = new Value() { Number = JsonConvert.SerializeObject(matrixOne), Action = action };

                        await dbContext.Values.AddAsync(entity);



                        await dbContext.SaveChangesAsync();
                        ResultForm resultForm = new ResultForm($@"������������ �����: {resultInt}");
                        resultForm.Show();
                    }
                    if (resultFloat is not null)
                    {
                        Models.Action action = new Models.Action() { ActionType = (ActionEnum)((ComboBoxItem)cbItem).Value, Result = resultFloat.ToString(), };
                        await dbContext.Actions.AddAsync(action);



                        Value entity = new Value() { Number = JsonConvert.SerializeObject(matrixOne), Action = action };

                        await dbContext.Values.AddAsync(entity);



                        await dbContext.SaveChangesAsync();
                        ResultForm resultForm = new ResultForm($@"������������ �����: {resultFloat}");
                        resultForm.Show();

                    }
                }
                else
                {
                    MessageBox.Show("�� ������ ��� ��������.");
                }


            }


        }

        private void MatrixOneDataDridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            string valueCell = MatrixOneDataDridView.CurrentCell.Value.ToString()!;
            if (valueCell.Contains("."))
                valueCell = valueCell.Replace(".", ",");
            MatrixOneDataDridView.CellValueChanged -= MatrixOneDataDridView_CellValueChanged!;

            bool validateValueTypeInt = Int32.TryParse(valueCell, out int valueIntCell);
            bool validateValueTypeFloat = Single.TryParse(valueCell, out float valueFloatCell);


            if (validateValueTypeFloat)
                MatrixOneDataDridView.CurrentCell.Value = valueFloatCell;
            else if (validateValueTypeInt)
                MatrixOneDataDridView.CurrentCell.Value = valueIntCell;
            else
            {
                MatrixOneDataDridView.CurrentCell.Value = 0;
                MessageBox.Show("������������ ��������.");
            }

            MatrixOneDataDridView.CellValueChanged += MatrixOneDataDridView_CellValueChanged!;

        }

        private void MatrixTwoDataDridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string valueCell = MatrixTwoDataDridView.CurrentCell.Value.ToString()!;
            if (valueCell.Contains("."))
                valueCell = valueCell.Replace(".", ",");
            MatrixTwoDataDridView.CellValueChanged -= MatrixTwoDataDridView_CellValueChanged!;

            bool validateValueTypeInt = Int32.TryParse(valueCell, out int valueIntCell);
            bool validateValueTypeFloat = Single.TryParse(valueCell, out float valueFloatCell);


            if (validateValueTypeFloat)
                MatrixTwoDataDridView.CurrentCell.Value = valueFloatCell;
            else if (validateValueTypeInt)
                MatrixTwoDataDridView.CurrentCell.Value = valueIntCell;
            else
            {
                MatrixTwoDataDridView.CurrentCell.Value = 0;
                MessageBox.Show("������������ ��������.");
            }
            MatrixTwoDataDridView.CellValueChanged += MatrixTwoDataDridView_CellValueChanged!;
        }
        protected internal void showLoader()
        {
            lock (pictureBox1)
            {
                pictureBox1.BringToFront();
                pictureBox1.Visible = true;
                pictureBox1.Dock = DockStyle.Fill;
                menuStrip1.Visible = false;
            }

        }

        protected internal void closeLoader()
        {
            lock (pictureBox1)
            {
                pictureBox1.Visible = false;
                menuStrip1.Visible = true;
            }

        }
    }
}

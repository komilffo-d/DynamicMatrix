using Microsoft.Office.Interop.Word;
using Syroot.Windows.IO;
using System.Data;
using DataTable = System.Data.DataTable;
using Range = Microsoft.Office.Interop.Word.Range;

namespace DynamicMatrix_WF
{
    public partial class ResultForm : Form
    {
        private string[,] _matrix1 = null!;
        private string[,] _matrix2 = null!;
        public ResultForm(string[,] result, string[,] matrix1 = null!, string[,] matrix2 = null!)
        {
            InitializeComponent();
            menuStrip1.Visible = true;
            menuStrip1.Enabled = true;
            ResultDataGridView.Visible = true;
            FillMatrix(result);
            _matrix1 = matrix1;
            _matrix2 = matrix2;

        }
        public ResultForm(string data)
        {
            InitializeComponent();
            label2.Visible = true;
            label2.Text = data;

        }


        private void FillMatrix(string[,] matrix)
        {

            DataTable table = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                DataColumn column = new DataColumn((i + 1).ToString());
                column.DefaultValue = 0;
                table.Columns.Add(column);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataRow row = table.NewRow();

                table.Rows.Add(row);
            }

            ResultDataGridView.DataSource = table;
            foreach (DataGridViewColumn column in ResultDataGridView.Columns)

            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in ResultDataGridView.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();

            if (matrix is not null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        ResultDataGridView.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }

            }

            ResultDataGridView.Refresh();
        }

        private void fileTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog1.InitialDirectory = KnownFolders.Downloads.Path;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {

                    if (_matrix1 is not null && _matrix1.Length > 0)
                    {
                        sw.WriteLine("/*** Матрица№1 ***/\n");
                        for (int i = 0; i < _matrix1.GetLength(0); i++)
                        {
                            for (int j = 0; j < _matrix1.GetLength(1); j++)
                            {
                                sw.Write(_matrix1[i, j].ToString() + "\t");
                            }
                            sw.WriteLine("");
                        }
                        sw.Write("\n\n");
                    }

                    if (_matrix2 is not null && _matrix2.Length>0)
                    {
                        sw.WriteLine("/*** Матрица№2 ***/\n");
                        for (int i = 0; i < _matrix2.GetLength(0); i++)
                        {
                            for (int j = 0; j < _matrix2.GetLength(1); j++)
                            {
                                sw.Write(_matrix2[i, j].ToString() + "\t");
                            }
                            sw.WriteLine("");
                        }
                        sw.Write("\n\n");
                    }

                    sw.WriteLine("/*** Результирующая матрица ***/\n");
                    foreach (DataGridViewRow row in ResultDataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sw.Write(cell.Value + "\t");
                        }
                        sw.WriteLine("");
                    }


                }
                MessageBox.Show("Данные успешно выведены в файл TXT.", "Экспорт в TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fileWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word Документы (*.docx)|*.docx";
            saveFileDialog1.InitialDirectory = KnownFolders.Downloads.Path;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = wordApp.Documents.Add();
                object myMissingValue = System.Reflection.Missing.Value;
                Paragraph newParagraph = null!;
                if (_matrix1 is not null && _matrix1.Length > 0)
                {
                    doc.Content.Text= "Матрица #1";
                    doc.Range().InsertParagraphAfter();
                    Table table_1 = doc.Tables.Add(doc.Range().Paragraphs.Last.Range, _matrix1.GetLength(0) + 1, _matrix1.GetLength(1), WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);
                    table_1.Borders.Enable = 1;
                    table_1.Range.Font.Size = 12;
                    table_1.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                    table_1.Range.ParagraphFormat.SpaceAfter = 6;
                    table_1.Rows[1].Cells.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                    for (int i = 0; i < _matrix1.GetLength(1); i++)
                    {
                        table_1.Cell(1, i + 1).Range.Text = (i+1).ToString();
                    }

                    for (int i = 0; i < _matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < _matrix1.GetLength(1); j++)
                        {
                            table_1.Cell(i + 2, j + 1).Range.Text = _matrix1[i,j].ToString();
                        }
                    }
                }



                if (_matrix2 is not null && _matrix2.Length > 0)
                {
                    doc.Range().InsertParagraphAfter();
                    newParagraph = doc.Paragraphs.Add(doc.Range().Paragraphs.Last.Range);
                    newParagraph.Range.Text = "Матрица #2";
                    doc.Range().InsertParagraphAfter();
                    Table table_2 = doc.Tables.Add(doc.Range().Paragraphs.Last.Range, _matrix2.GetLength(0) + 1, _matrix2.GetLength(1), WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);
                    table_2.Borders.Enable = 1;
                    table_2.Range.Font.Size = 12;
                    table_2.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                    table_2.Range.ParagraphFormat.SpaceAfter = 6;
                    table_2.Rows[1].Cells.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                    for (int i = 0; i < _matrix2.GetLength(1); i++)
                    {
                        table_2.Cell(1, i + 1).Range.Text = (i + 1).ToString();
                    }

                    for (int i = 0; i < _matrix2.GetLength(0); i++)
                    {
                        for (int j = 0; j < _matrix2.GetLength(1); j++)
                        {
                            table_2.Cell(i + 2, j + 1).Range.Text = _matrix2[i, j].ToString();
                        }
                    }
                }
                doc.Range().InsertParagraphAfter();
                newParagraph = doc.Paragraphs.Add(doc.Range().Paragraphs.Last.Range);
                newParagraph.Range.Text = "Результирующая матрица";
                doc.Range().InsertParagraphAfter();
                Table table = doc.Tables.Add(doc.Range().Paragraphs.Last.Range, ResultDataGridView.Rows.Count + 1, ResultDataGridView.ColumnCount, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);
                table.Borders.Enable = 1;
                table.Range.Font.Size = 12;
                table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                table.Range.ParagraphFormat.SpaceAfter = 6;
                table.Rows[1].Cells.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                for (int i = 0; i < ResultDataGridView.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = ResultDataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < ResultDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < ResultDataGridView.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = ResultDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                object fileName = saveFileDialog1.FileName;
                doc.SaveAs2(ref fileName);

                doc.Close();
                wordApp.Quit();

                MessageBox.Show("Данные успешно выведены в файл Word.", "Экспорт в Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

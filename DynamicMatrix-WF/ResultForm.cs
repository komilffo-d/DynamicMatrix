using Microsoft.Office.Interop.Word;
using Syroot.Windows.IO;
using System.Data;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace DynamicMatrix_WF
{
    public partial class ResultForm : Form
    {
        public ResultForm(string[,] data)
        {
            InitializeComponent();
            menuStrip1.Visible = true;
            menuStrip1.Enabled = true;
            ResultDataGridView.Visible = true;
            FillMatrix(data);

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
                column.Width = 30;
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
            if (matrix is not null)
                ResultDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
                    sw.WriteLine("/*** Матрица #1 ***/\n");
                    foreach (DataGridViewRow row in ResultDataGridView.Rows)
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
            saveFileDialog1.Filter = "Word Документы (*.docx)|*.docx";
            saveFileDialog1.InitialDirectory = KnownFolders.Downloads.Path;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                Document doc = wordApp.Documents.Add();

                Table table = doc.Tables.Add(doc.Range(), ResultDataGridView.Rows.Count + 1, ResultDataGridView.ColumnCount);

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

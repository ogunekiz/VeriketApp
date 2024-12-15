using System.Data;
using VeriketApp.Settings;

namespace VeriketApp.WinForm.UI
{
    public partial class frmGetLogs : Form
    {
        public frmGetLogs()
        {
            InitializeComponent();
        }

        private void btnGetLogs_Click(object sender, EventArgs e)
        {
            string veriketAppFolderName = VeriketAppSettings.VeriketAppFolderName;
            string csvFileName = VeriketAppSettings.CsvFileName;

            string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string veriketAppFolder = Path.Combine(programDataPath, veriketAppFolderName);
            string filePath = Path.Combine(veriketAppFolder, csvFileName);

            if (File.Exists(filePath))
            {
                DataTable dataTable = LoadCsvToDataTable(filePath);
                dgvLogList.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show($"CSV dosyası belirtilen konumda bulunamadı!\nKonum: {filePath}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable LoadCsvToDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    bool isFirstRow = true;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] values = line.Split(',');

                        if (isFirstRow)
                        {
                            foreach (string column in values)
                            {
                                dataTable.Columns.Add(column.Trim());
                            }
                            isFirstRow = false;
                        }
                        else
                        {
                            dataTable.Rows.Add(values);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


    }
}

using VeriketApp.Settings;

namespace VeriketApp.Service
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            int delayMinute = VeriketAppSettings.DelayMinute;
            string veriketAppFolderName = VeriketAppSettings.VeriketAppFolderName;
            string csvFileName = VeriketAppSettings.CsvFileName;
            string csvFileHeaderRow = VeriketAppSettings.CsvFileHeaderRow;

            while (!stoppingToken.IsCancellationRequested)
            {

                await GetInfoAsync(veriketAppFolderName, csvFileName, csvFileHeaderRow);

                await Task.Delay(TimeSpan.FromMinutes(delayMinute), stoppingToken);
            }
        }

        private static async Task GetInfoAsync(string veriketAppFolderName, string txtFileName, string csvFileHeaderRow)
        {
            string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string veriketAppFolder = Path.Combine(programDataPath, veriketAppFolderName);
            string testFilePath = Path.Combine(veriketAppFolder, txtFileName);

            EnsureFolderExists(veriketAppFolder);

            if (!File.Exists(testFilePath))
                await File.WriteAllTextAsync(testFilePath, csvFileHeaderRow);

            string csvLine = GenerateCsvLine();

            await File.AppendAllTextAsync(testFilePath, csvLine + Environment.NewLine);
        }

        private static void EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        private static string GenerateCsvLine()
        {
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            string userName = Environment.UserName;

            return $"{date},{computerName},{userName}";
        }

    }
}

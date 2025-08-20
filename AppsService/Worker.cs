using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace AppsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //-variables------
            object Result;
            int Numbers;
            List<string> Directories = new List<string>();
            //-variables------

            //Sqlite----
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Logs\\Apps.db");
            SqliteCommand command = new SqliteCommand();
            //sqlite----

             // Open a new Connection
             connection.Open();
             command.Connection = connection; 

            //Get All of AppIDs
            command.CommandText = "SELECT MAX(AppID) AS AppID FROM Apps";
            Result = command.ExecuteScalar();
            connection.Close();

            //convert String to int
            Numbers = Convert.ToInt32(Result);
            
            //Get Directories
            for (int Check = 0; Check <= Numbers - 1; Check++)
            {
               connection.Open();
               command.CommandText = $"SELECT AppDirectory From Apps Where AppID = {Numbers}";
               Result = command.ExecuteScalar();
               connection.Close();
               Directories.Add(Result.ToString());
            }

            //Run Application
            for(int Check = 0; Check <= Directories.Count -1; Check++)
            {
               ProcessStartInfo info = new ProcessStartInfo
               {
                   FileName = "powershell",
                   Arguments = $"& \'{Directories[Check]}\'",
                   WorkingDirectory = @$"C:\Logs",
                   RedirectStandardOutput = true,
                   RedirectStandardError = true,
                   UseShellExecute = false, 
                   CreateNoWindow = false
               };

               Process process = new Process();
               process.StartInfo = info;
               process.Start();
                
            }
           
           await Task.Delay(-1, stoppingToken);
        }
    }
}

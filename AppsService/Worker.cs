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
            while (!stoppingToken.IsCancellationRequested)
            {
                object Result;
                int Numbers;
                List<string> Directories = new List<string>();

                SqliteConnection connection = new SqliteConnection("Data Source=Apps.db");
                SqliteCommand command = new SqliteCommand();

                connection.Open();
                command.Connection = connection; 
                command.CommandText = "SELECT MAX(AppID) AS AppID FROM Apps";
                Result = command.ExecuteScalar();
                connection.Close();

                Numbers = Convert.ToInt32(Result);

                for (int Check = 0; Check <= Numbers; Check++)
                {
                    connection.Open();
                    command.CommandText = $"SELECT AppDirectory From Apps Where AppID = {Numbers}";
                    Result = command.ExecuteScalar();
                    connection.Close();
                    Directories.Add(Result.ToString());
                }

                for(int Check = 0; Check <= Directories.Count -1; Check++)
                {
                    Process.Start(Directories[Check]);
                }

                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
        }
    }
}

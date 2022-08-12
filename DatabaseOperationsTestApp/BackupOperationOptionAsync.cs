namespace DatabaseOperationsTestApp
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using DatabaseOperations.DataTransferObjects;
    using DatabaseOperations.Interfaces;
    using DatabaseOperations.Operators;

    internal static class BackupOperationOptionAsync
    {
        internal static async Task DemoOperationOptionAsync()
        {
            Console.WriteLine("Welcome to the database backup test application.");
            Console.WriteLine("Testing the async backup method using the new option pattern.");

            const string connectionString = @"server=MyComputer\SQLInstance;database=MyDatabase;Integrated Security=SSPI;Connect Timeout=30;";
            const string backupPath = @"E:\Database\Backups\";
            IBackupOperator backupOperator = new BackupOperator();
            var cancellationSource = new CancellationTokenSource();

            OperationResult result = await backupOperator.BackupDatabaseAsync(
                connectionString,
                options => { options.BackupPath = backupPath; },
                cancellationSource.Token);

            string messageDetails = result.Messages.Any() ? string.Join(", ", result.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionString}' was successful - '{result.Result}'. Messages: {messageDetails}.");
        }
    }
}

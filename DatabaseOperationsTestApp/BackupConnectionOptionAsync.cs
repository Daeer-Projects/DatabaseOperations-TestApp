namespace DatabaseOperationsTestApp
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using DatabaseOperations.DataTransferObjects;
    using DatabaseOperations.Interfaces;
    using DatabaseOperations.Operators;

    internal static class BackupConnectionOptionAsync
    {
        internal static async Task DemoConnectionOptionAsync()
        {
            Console.WriteLine("Welcome to the database backup test application.");
            Console.WriteLine("Testing the backup method using the original async backup method.");

            const string connectionString = @"server=MyComputer\SQLInstance;database=MyDatabase;Integrated Security=SSPI;Connect Timeout=30;";
            IBackupOperator backupOperator = new BackupOperator();

            OperationResult result = await backupOperator.BackupDatabaseAsync(new ConnectionOptions(connectionString), CancellationToken.None);

            string messageDetails = result.Messages.Any() ? string.Join(", ", result.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionString}' was successful - '{result.Result}'. Messages: {messageDetails}.");
        }
    }
}

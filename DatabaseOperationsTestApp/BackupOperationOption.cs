namespace DatabaseOperationsTestApp
{
    using System;
    using System.Linq;
    using DatabaseOperations.DataTransferObjects;
    using DatabaseOperations.Interfaces;
    using DatabaseOperations.Operators;

    internal static class BackupOperationOption
    {
        internal static void DemoOperationOption()
        {
            Console.WriteLine("Welcome to the database backup test application.");
            Console.WriteLine("Testing the basic backup method using the new option pattern.");

            const string connectionString = @"server=MyComputer\SQLInstance;database=MyDatabase;Integrated Security=SSPI;Connect Timeout=30;";
            const string backupPath = @"E:\Database\Backups\";
            IBackupOperator backupOperator = new BackupOperator();

            OperationResult result = backupOperator.BackupDatabase(
                connectionString,
                options => { options.BackupPath = backupPath; });

            string messageDetails = result.Messages.Any() ? string.Join(", ", result.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionString}' was successful - '{result.Result}'. Messages: {messageDetails}.");
        }
    }
}

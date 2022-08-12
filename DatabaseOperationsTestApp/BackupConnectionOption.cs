namespace DatabaseOperationsTestApp
{
    using System;
    using System.Linq;
    using DatabaseOperations.DataTransferObjects;
    using DatabaseOperations.Interfaces;
    using DatabaseOperations.Operators;

    internal class BackupConnectionOption
    {
        internal static void DemoConnectionOption()
        {
            Console.WriteLine("Welcome to the database backup test application.");
            Console.WriteLine("Testing the backup method using the original basic backup method.");

            const string connectionString = @"server=MyComputer\SQLInstance;database=MyDatabase;Integrated Security=SSPI;Connect Timeout=30;";
            IBackupOperator backupOperator = new BackupOperator();

            OperationResult result = backupOperator.BackupDatabase(new ConnectionOptions(connectionString));

            string messageDetails = result.Messages.Any() ? string.Join(", ", result.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionString}' was successful - '{result.Result}'. Messages: {messageDetails}.");
        }
    }
}

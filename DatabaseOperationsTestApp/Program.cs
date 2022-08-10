using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DatabaseOperations.DataTransferObjects;
using DatabaseOperations.Operators;

namespace DatabaseOperationsTestApp
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Welcome to the database backup test application.");
            var backupOperator = new BackupOperator();

            const string connectionStringCombination = @"server=MADDY\SQLDEV;database=LottoCombination;Integrated Security=SSPI;Connect Timeout=5;";
            const string connectionStringSystem = @"server=MADDY\SQLDEV;database=LottoSystem;Integrated Security=SSPI;Connect Timeout=5;";
            const string connectionStringIdentity = @"server=MADDY\SQLDEV;database=IdentityServer;Integrated Security=SSPI;Connect Timeout=5;";
            //const string backupPath = @"\\192.168.16.205\C$\Database\Backups\";
            const string backupPath = @"E:\Database\Backups\";
            var cancellationSource = new CancellationTokenSource();
            var token = cancellationSource.Token;
            //string backupPath = string.Empty;

            //var resultCombination = backupOperator.BackupDatabaseAsync(new ConnectionOptions(connectionStringCombination, backupPath), token);
            //var resultSystem = backupOperator.BackupDatabaseAsync(new ConnectionOptions(connectionStringSystem, backupPath), token);
            //var resultIdentity = backupOperator.BackupDatabaseAsync(new ConnectionOptions(connectionStringIdentity, backupPath), token);

            var resultCombination = backupOperator.BackupDatabaseAsync(
                connectionStringCombination,
                options => { options.BackupPath = backupPath; },
                token);
            var resultSystem = backupOperator.BackupDatabaseAsync(
                connectionStringSystem,
                options =>
                {
                    options.BackupPath = backupPath;
                },
                token);
            var resultIdentity = backupOperator.BackupDatabaseAsync(
                connectionStringIdentity,
                options =>
                {
                    options.BackupPath = backupPath;
                },
                token);

            await Task.WhenAll(resultCombination, resultSystem, resultIdentity).ConfigureAwait(false);

            var combinationTask = await resultCombination.ConfigureAwait(false);
            var systemTask = await resultSystem.ConfigureAwait(false);
            var identityTask = await resultIdentity.ConfigureAwait(false);

            var messageDetails = combinationTask.Messages.Any() ? string.Join(", ", combinationTask.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionStringCombination}' was successful - '{combinationTask.Result}'. Messages: {messageDetails}.");

            messageDetails = systemTask.Messages.Any() ? string.Join(", ", systemTask.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionStringSystem}' was successful - '{systemTask.Result}'. Messages: {messageDetails}.");

            messageDetails = identityTask.Messages.Any() ? string.Join(", ", identityTask.Messages) : "No messages.";
            Console.WriteLine($"Backup of database using connection string '{connectionStringIdentity}' was successful - '{identityTask.Result}'. Messages: {messageDetails}.");
        }
    }
}

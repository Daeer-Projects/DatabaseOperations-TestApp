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

            BackupConnectionOption.DemoConnectionOption();

            await BackupConnectionOptionAsync.DemoConnectionOptionAsync();

            BackupOperationOption.DemoOperationOption();

            await BackupOperationOptionAsync.DemoOperationOptionAsync();
        }
    }
}

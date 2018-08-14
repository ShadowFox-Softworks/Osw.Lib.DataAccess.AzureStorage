namespace OSW.Lib.DataAccess.AzureStorage.Test.Integration.Queue
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Entity;
    using Interface;
    using Logic.Queue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestData;

    [TestClass]
    public class DeleteIfExistsTests : TestBase
    {
        private IAzureStorageQueue azureStorageQueue;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            var azureStorageQueueConfig = new AzureStorageQueueConfig
            {
                ConnectionString = AzureStorageData.ConnectionString,
                QueueName = "osw-lib-dataaccess-azurestorage"
            };

            this.azureStorageQueue = AzureStorageQueueFactory.Create(
                this.LoggerFactoryEnriched,
                azureStorageQueueConfig);

            this.azureStorageQueue.CreateIfNotExists();
        }

        [TestMethod]
        public void WhenQueueDeleted_DeleteIfExists_ExpectNoException()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            this.azureStorageQueue.DeleteIfExists();

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public async Task WhenQueueDeleted_DeleteIfExistsAsync_ExpectNoException()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            await this.azureStorageQueue.DeleteIfExistsAsync();

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }
    }
}
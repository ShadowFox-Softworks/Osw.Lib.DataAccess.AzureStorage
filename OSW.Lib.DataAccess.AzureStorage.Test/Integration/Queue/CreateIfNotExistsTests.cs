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
    public class CreateIfNotExistsTests : TestBase
    {
        private IAzureStorageQueue azureStorageQueue;

        [TestCleanup]
        public void TestCleanup()
        {
            this.azureStorageQueue.DeleteIfExists();
        }

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
        }

        [TestMethod]
        public void WhenQueueNotExists_CreateIfNoyExists_ExpectQueueCreated()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            this.azureStorageQueue.CreateIfNotExists();

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public async Task WhenQueueNotExists_CreateIfNoyExistsAsync_ExpectQueueCreated()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            await this.azureStorageQueue.CreateIfNotExistsAsync();

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }
    }
}
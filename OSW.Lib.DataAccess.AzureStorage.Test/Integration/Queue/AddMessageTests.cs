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
    public sealed class AddMessageTests : TestBase
    {
        private IAzureStorageQueue azureStorageQueue;

        private TestQueueMessage testQueueMessage;

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

            this.azureStorageQueue.CreateIfNotExists();

            this.testQueueMessage = new TestQueueMessage
            {
                Author = "Orisic Softworks"
            };
        }

        [TestMethod]
        public void WhenMessageSubmitted_AddMessage_ExpectMessageOnQueue()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            this.azureStorageQueue.AddMessage(this.testQueueMessage);

            stopwatch.Stop();

            // Assert
            var retrievedQueueMessage = this.azureStorageQueue.GetMessage<TestQueueMessage>();

            Assert.AreEqual(this.testQueueMessage.Author, retrievedQueueMessage.Author);

            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public async Task WhenMessageSubmitted_AddMessageAsync_ExpectMessageOnQueue()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            await this.azureStorageQueue.AddMessageAsync(this.testQueueMessage);

            stopwatch.Stop();

            // Assert
            var retrievedQueueMessage = this.azureStorageQueue.GetMessage<TestQueueMessage>();

            Assert.AreEqual(this.testQueueMessage.Author, retrievedQueueMessage.Author);

            WriteTimeElapsed(stopwatch);
        }
    }
}
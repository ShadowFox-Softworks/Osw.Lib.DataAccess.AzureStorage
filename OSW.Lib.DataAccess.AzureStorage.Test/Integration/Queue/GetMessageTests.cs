namespace OSW.Lib.DataAccess.AzureStorage.Test.Integration.Queue
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Entity;
    using Interface;
    using Logic.Queue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestData;

    [TestClass]
    public class GetMessageTests : TestBase
    {
        private const string OrisicSoftworks = "Orisic Softworks";

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
                Author = OrisicSoftworks
            };
        }

        [TestMethod]
        public void WhenMessageOnQueue_GetMessage_ExpectMessageRetrieval()
        {
            // Arrange
            this.azureStorageQueue.AddMessage(this.testQueueMessage);

            // Act
            var stopwatch = Stopwatch.StartNew();

            var queueMessage = this.azureStorageQueue.GetMessage<TestQueueMessage>();

            stopwatch.Stop();

            // Assert
            Assert.IsNotNull(queueMessage.Author);

            Assert.AreEqual(queueMessage.Author, OrisicSoftworks);

            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public async Task WhenMessageOnQueue_GetMessageAsync_ExpectMessageRetrieval()
        {
            // Arrange
            this.azureStorageQueue.AddMessage(this.testQueueMessage);

            // Act
            var stopwatch = Stopwatch.StartNew();

            var queueMessage = await this.azureStorageQueue.GetMessageAsync<TestQueueMessage>().ConfigureAwait(false);

            stopwatch.Stop();

            // Assert
            Assert.IsNotNull(queueMessage.Author);

            Assert.AreEqual(queueMessage.Author, OrisicSoftworks);

            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public void WhenNoMessageOnQueue_GetMessage_ExpectException()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            Assert.ThrowsException<NullReferenceException>(
                () => this.azureStorageQueue.GetMessage<TestQueueMessage>());

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }

        [TestMethod]
        public async Task WhenNoMessageOnQueue_GetMessageAsync_ExpectException()
        {
            // Act
            var stopwatch = Stopwatch.StartNew();

            await Assert.ThrowsExceptionAsync<NullReferenceException>(
                () => this.azureStorageQueue.GetMessageAsync<TestQueueMessage>());

            stopwatch.Stop();

            // Assert
            WriteTimeElapsed(stopwatch);
        }
    }
}
namespace OSW.Lib.DataAccess.AzureStorage.Logic.Queue
{
    using System;
    using System.Threading.Tasks;
    using Entity;
    using Helper;
    using Interface;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <seealso cref="OSW.Lib.DataAccess.AzureStorage.Interface.IAzureStorageQueue" />
    public sealed class AzureStorageQueue : IAzureStorageQueue
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(AzureStorageQueue);

        /// <summary>
        /// The cloud queue
        /// </summary>
        private readonly CloudQueue cloudQueue;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageQueue"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="azureStorageQueueConfig">The azure storage queue configuration.</param>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// azureStorageQueueConfig
        /// </exception>
        internal AzureStorageQueue(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] AzureStorageQueueConfig azureStorageQueueConfig)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (azureStorageQueueConfig == null)
            {
                throw new ArgumentNullException(nameof(azureStorageQueueConfig));
            }

            var cloudStorageAccount = CloudStorageAccount.Parse(azureStorageQueueConfig.ConnectionString);
            var cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            this.cloudQueue = cloudQueueClient.GetQueueReference(azureStorageQueueConfig.QueueName);
            this.logger = loggerFactory.CreateLogger<AzureStorageQueue>();
        }

        /// <inheritdoc />
        public void AddMessage(object message)
        {
            const string MethodName = nameof(this.AddMessage);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var messageAsJson = JsonConvert.SerializeObject(message);
                var cloudQueueMessage = new CloudQueueMessage(messageAsJson);

                this.cloudQueue.AddMessageAsync(cloudQueueMessage).Wait();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task AddMessageAsync(object message)
        {
            const string MethodName = nameof(this.AddMessageAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                var messageAsJson = JsonConvert.SerializeObject(message);
                var cloudQueueMessage = new CloudQueueMessage(messageAsJson);

                await this.cloudQueue.AddMessageAsync(cloudQueueMessage).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public void CreateIfNotExists()
        {
            const string MethodName = nameof(this.CreateIfNotExists);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // [Special:Hyphens][HighCase:N][LowCase:Y][Numbers:Y]
                this.cloudQueue.CreateIfNotExistsAsync().Wait();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task CreateIfNotExistsAsync()
        {
            const string MethodName = nameof(this.CreateIfNotExistsAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // [Special:Hyphens][HighCase:N][LowCase:Y][Numbers:Y]
                await this.cloudQueue.CreateIfNotExistsAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public void DeleteIfExists()
        {
            const string MethodName = nameof(this.DeleteIfExists);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                this.cloudQueue.DeleteIfExistsAsync().Wait();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task DeleteIfExistsAsync()
        {
            const string MethodName = nameof(this.DeleteIfExistsAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                await this.cloudQueue.DeleteIfExistsAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public TType GetMessage<TType>()
        {
            const string MethodName = nameof(this.GetMessage);
            this.logger.MethodStart(ClassName, MethodName);

            TType messageAsPoco;
            try
            {
                var cloudQueueMessage = this.cloudQueue.GetMessageAsync().Result;
                var messageAsString = cloudQueueMessage.AsString;
                messageAsPoco = JsonConvert.DeserializeObject<TType>(messageAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return messageAsPoco;
        }

        /// <inheritdoc />
        public async Task<TType> GetMessageAsync<TType>()
        {
            const string MethodName = nameof(this.GetMessageAsync);
            this.logger.MethodStart(ClassName, MethodName);

            TType messageAsPoco;
            try
            {
                var cloudQueueMessage = await this.cloudQueue.GetMessageAsync().ConfigureAwait(false);
                var messageAsString = cloudQueueMessage.AsString;
                messageAsPoco = JsonConvert.DeserializeObject<TType>(messageAsString);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
            return messageAsPoco;
        }
    }
}
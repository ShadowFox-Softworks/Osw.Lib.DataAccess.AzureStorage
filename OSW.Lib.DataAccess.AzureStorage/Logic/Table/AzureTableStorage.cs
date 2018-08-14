namespace OSW.Lib.DataAccess.AzureStorage.Logic.Table
{
    using System;
    using System.Threading.Tasks;
    using Entity;
    using Helper;
    using Interface;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    /// <inheritdoc />
    /// <seealso cref="OSW.Lib.DataAccess.AzureStorage.Interface.IAzureStorageTable" />
    public sealed class AzureTableStorage : IAzureStorageTable
    {
        /// <summary>
        /// The class name
        /// </summary>
        private const string ClassName = nameof(AzureTableStorage);

        /// <summary>
        /// The cloud table
        /// </summary>
        private readonly CloudTable cloudTable;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureTableStorage"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="azureStorageTableConfig">The azure storage table configuration.</param>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// azureStorageTableConfig
        /// </exception>
        internal AzureTableStorage(
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] AzureStorageTableConfig azureStorageTableConfig)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (azureStorageTableConfig == null)
            {
                throw new ArgumentNullException(nameof(azureStorageTableConfig));
            }

            var cloudStorageAccount = CloudStorageAccount.Parse(azureStorageTableConfig.ConnectionString);
            var cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

            this.cloudTable = cloudTableClient.GetTableReference(azureStorageTableConfig.TableName);
            this.logger = loggerFactory.CreateLogger<AzureTableStorage>();
        }

        /// <inheritdoc />
        public void CreateIfNotExists()
        {
            const string MethodName = nameof(this.CreateIfNotExists);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // [Special:N][HighCase:Y][LowCase:Y][Numbers:Y]
                this.cloudTable.CreateIfNotExistsAsync().Wait();
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
                // [Special:N][HighCase:Y][LowCase:Y][Numbers:Y]
                await this.cloudTable.CreateIfNotExistsAsync().ConfigureAwait(false);
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
                this.cloudTable.DeleteIfExistsAsync().Wait();
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
                await this.cloudTable.DeleteIfExistsAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public TType RetrieveRange<TType>()
        {
            const string MethodName = nameof(this.RetrieveRange);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetrieveRange implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<TType> RetrieveRangeAsync<TType>()
        {
            const string MethodName = nameof(this.RetrieveRangeAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetrieveRangeAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public TType RetrieveSingle<TType>()
        {
            const string MethodName = nameof(this.RetrieveSingle);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetrieveSingle implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<TType> RetrieveSingleAsync<TType>()
        {
            const string MethodName = nameof(this.RetrieveSingleAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetrieveSingleAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public TType RetriveAll<TType>()
        {
            const string MethodName = nameof(this.RetriveAll);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetriveAll implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }

        /// <inheritdoc />
        public async Task<TType> RetriveAllAsync<TType>()
        {
            const string MethodName = nameof(this.RetriveAllAsync);
            this.logger.MethodStart(ClassName, MethodName);

            try
            {
                // TODO: RetriveAllAsync implementation
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                this.logger.LogException(exception, ClassName, MethodName);
                throw;
            }

            this.logger.MethodEnd(ClassName, MethodName);
        }
    }
}
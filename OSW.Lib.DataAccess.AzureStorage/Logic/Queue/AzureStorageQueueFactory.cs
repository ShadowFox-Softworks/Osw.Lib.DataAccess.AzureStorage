namespace OSW.Lib.DataAccess.AzureStorage.Logic.Queue
{
    using System;
    using Entity;
    using Interface;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Azure Storage Queue Factory
    /// </summary>
    public static class AzureStorageQueueFactory
    {
        /// <summary>
        /// The queue factory lazy
        /// </summary>
        private static readonly Lazy<IAzureStorageQueue> Lazy = new Lazy<IAzureStorageQueue>(Initilize);

        /// <summary>
        /// The local azure storage queue configuration
        /// </summary>
        private static AzureStorageQueueConfig localAzureStorageQueueConfig;

        /// <summary>
        /// The local logger factory
        /// </summary>
        private static ILoggerFactory localLoggerFactory;

        /// <summary>
        /// Creates the specified logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="azureStorageQueueConfig">The azure storage queue configuration.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// loggerFactory
        /// or
        /// azureStorageQueueConfig
        /// </exception>
        public static IAzureStorageQueue Create(
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

            localLoggerFactory = loggerFactory;
            localAzureStorageQueueConfig = azureStorageQueueConfig;

            return Lazy.Value;
        }

        /// <summary>
        /// Initilizes this instance.
        /// </summary>
        /// <returns>
        ///   <see cref="IAzureStorageQueue"/>
        /// </returns>
        private static IAzureStorageQueue Initilize()
        {
            var azureQueueStorage = new AzureStorageQueue(
                localLoggerFactory,
                localAzureStorageQueueConfig);

            return azureQueueStorage;
        }
    }
}
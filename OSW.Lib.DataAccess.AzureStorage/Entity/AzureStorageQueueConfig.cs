namespace OSW.Lib.DataAccess.AzureStorage.Entity
{
    /// <summary>
    /// The Azure Storage Queue Config
    /// </summary>
    public sealed class AzureStorageQueueConfig
    {
        /// <summary>
        /// Gets or sets the connection string of the queue.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the queue.
        /// </summary>
        public string QueueName { get; set; }
    }
}
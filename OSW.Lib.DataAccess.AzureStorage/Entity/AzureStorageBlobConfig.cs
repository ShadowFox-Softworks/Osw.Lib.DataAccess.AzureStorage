namespace OSW.Lib.DataAccess.AzureStorage.Entity
{
    /// <summary>
    /// The Azure Storage Blob Config
    /// </summary>
    public sealed class AzureStorageBlobConfig
    {
        /// <summary>
        /// Gets or sets the name of the blob.
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// Gets or sets the connection string of the blob.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
namespace OSW.Lib.DataAccess.AzureStorage.Entity
{
    /// <summary>
    /// The Azure Storage Table Config
    /// </summary>
    public sealed class AzureStorageTableConfig
    {
        /// <summary>
        /// Gets or sets the connection string of the table.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        public string TableName { get; set; }
    }
}
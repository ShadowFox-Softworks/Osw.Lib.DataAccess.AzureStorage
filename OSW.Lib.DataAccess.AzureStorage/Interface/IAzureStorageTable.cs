namespace OSW.Lib.DataAccess.AzureStorage.Interface
{
    using System.Threading.Tasks;

    /// <summary>
    /// The Azure Table Storage
    /// </summary>
    public interface IAzureStorageTable
    {
        /// <summary>
        /// Creates a table if does not already exist synchronously.
        /// </summary>
        void CreateIfNotExists();

        /// <summary>
        /// Creates a table if does not already exist asynchronously.
        /// </summary>
        /// <returns>
        ///   <see cref="Task"/>
        /// </returns>
        Task CreateIfNotExistsAsync();

        /// <summary>
        /// Deletes a table if it exists synchronously.
        /// </summary>
        void DeleteIfExists();

        /// <summary>
        /// Deletes a table if it exists asynchronously.
        /// </summary>
        /// <returns>
        ///   <see cref="Task"/>
        /// </returns>
        Task DeleteIfExistsAsync();

        /// <summary>
        /// Retrieves a range of data sets synchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="T:TType"/>
        /// </returns>
        TType RetrieveRange<TType>();

        /// <summary>
        /// Retrieves a range of data sets asynchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="Task{TResult}"/>
        /// </returns>
        Task<TType> RetrieveRangeAsync<TType>();

        /// <summary>
        /// Retrieves a single data set synchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="T:TType"/>
        /// </returns>
        TType RetrieveSingle<TType>();

        /// <summary>
        /// Retrieves a single data set asynchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="Task{TResult}"/>
        /// </returns>
        Task<TType> RetrieveSingleAsync<TType>();

        /// <summary>
        /// Retrives all data sets synchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="T:TType"/>
        /// </returns>
        TType RetriveAll<TType>();

        /// <summary>
        /// Retrives all data sets asynchronously.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <returns>
        ///   <see cref="Task{TResult}"/>
        /// </returns>
        Task<TType> RetriveAllAsync<TType>();
    }
}
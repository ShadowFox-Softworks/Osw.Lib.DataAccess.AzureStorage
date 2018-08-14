namespace OSW.Lib.DataAccess.AzureStorage.Interface
{
    using System.Threading.Tasks;

    /// <summary>
    /// The Azure Storage Queue
    /// </summary>
    public interface IAzureStorageQueue
    {
        /// <summary>
        /// Adds a message to a queue synchronously.
        /// </summary>
        /// <param name="message">The message.</param>
        void AddMessage(object message);

        /// <summary>
        /// Adds a message to a queue asynchronously.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task AddMessageAsync(object message);

        /// <summary>
        /// Creates a queue if does not already exist synchronously.
        /// </summary>
        void CreateIfNotExists();

        /// <summary>
        /// Creates a queue if does not already exist asynchronously.
        /// </summary>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task CreateIfNotExistsAsync();

        /// <summary>
        /// Deletes a queue if it exists synchronously.
        /// </summary>
        void DeleteIfExists();

        /// <summary>
        /// Deletes a queue if it exists asynchronously.
        /// </summary>
        /// <returns>
        ///   <see cref="Task" />
        /// </returns>
        Task DeleteIfExistsAsync();

        /// <summary>
        /// Gets a message from a queue synchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>
        ///   <see cref="!:TResult" />
        /// </returns>
        TResult GetMessage<TResult>();

        /// <summary>
        /// Gets a message from a queue asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>
        ///   <see cref="Task{TResult}" />
        /// </returns>
        Task<TResult> GetMessageAsync<TResult>();
    }
}
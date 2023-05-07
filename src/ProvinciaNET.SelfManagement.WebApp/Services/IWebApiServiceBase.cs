namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// WebApiService Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWebApiServiceBase<T> where T : class
    {
        /// <summary>
        /// Gets the odata asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="select">The select.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        Task<Radzen.ODataServiceResult<T>> GetOdataAsync(string? filter = null, int? top = null, int? skip = null, string? orderby = null, string? expand = null, string? select = null, bool? count = null);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync();

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        Task<T> CreateAsync(T resource);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        Task UpdateAsync(int id, T resource);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Exports to file.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="filename">The filename.</param>
        void ExportToFile(string fileType, string filename);
    }
}
namespace ProvinciaNET.SelfManagement.WebApi.Interfaces
{
    /// <summary>
    /// CrudBase Service Interface
    /// </summary>
    /// <typeparam name="T">Class to implement.</typeparam>
    public interface ICrudBaseService<T> where T : class
    {
        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Get();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T?> Get(int id);

        /// <summary>
        /// Posts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<T> Post(T entity);

        /// <summary>
        /// Puts the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Put(int id, T entity);

        /// <summary>
        /// Deletes the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
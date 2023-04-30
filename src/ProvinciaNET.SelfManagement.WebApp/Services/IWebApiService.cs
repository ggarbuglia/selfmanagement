namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    public interface IWebApiService<T> where T : class
    {
        Task<Radzen.ODataServiceResult<T>> GetOdataAsync(string? filter = null, int? top = null, int? skip = null, string? orderby = null, string? expand = null, string? select = null, bool? count = null);

        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(int id);

        Task<T> CreateAsync(T resource);

        Task UpdateAsync(int id, T resource);

        Task DeleteAsync(int id);

        void ExportToFile(string fileType, string filename);
    }
}
using ProvinciaNET.SelfManagement.Core.Entities;
using Radzen;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    public interface ISelfManagementWebApiService
    {
        Task<ODataServiceResult<OrgCostCenter>> GetOdataAsync(string? filter = null, int? top = null, int? skip = null, string? orderby = null, string? expand = null, string? select = null, bool? count = null);
        Task<IEnumerable<OrgCostCenter>> GetAsync();
        Task<OrgCostCenter> GetAsync(int id);
        Task<OrgCostCenter> CreateAsync(OrgCostCenter resource);
        Task UpdateAsync(int id, OrgCostCenter resource);
        Task DeleteAsync(int id);
        void ExportToFile(string fileType, string filename);
    }
}
using ProvinciaNET.SelfManagement.Core.Entities;
using Radzen;

namespace ProvinciaNET.SelfManagement.WebApp.Data
{
    public class OrgCostCentersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrgCostCentersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ODataServiceResult<OrgCostCenter>> GetOrgCostCenters(string? filter = default, int? top = default(int?), int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var result = new ODataServiceResult<OrgCostCenter>();

            var httpClient = _httpClientFactory.CreateClient("SelfManagementWebApi");
            if (httpClient != null) 
            {
                var uri = new Uri($"{httpClient.BaseAddress?.ToString()}odata/OrgCostCenters");
                uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);
                
                var request  = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await httpClient.SendAsync(request);
                result       = await response.ReadAsync<ODataServiceResult<OrgCostCenter>>();
            }

            return result;
        }
    }
}

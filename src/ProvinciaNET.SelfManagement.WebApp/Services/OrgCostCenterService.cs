using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Components;
using ProvinciaNET.SelfManagement.Core.Entities;
using Radzen;
using System.Text;
using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    public partial class OrgCostCenterService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        partial void OnGet(ODataServiceResult<OrgCostCenter> items);
        partial void OnGetById(OrgCostCenter item);
        partial void OnCreated(OrgCostCenter item);
        partial void AfterCreated(OrgCostCenter item);
        partial void OnUpdated(OrgCostCenter item);
        partial void AfterUpdated(OrgCostCenter item);
        partial void OnDeleted(OrgCostCenter item);
        partial void AfterDeleted(OrgCostCenter item);

        public OrgCostCenterService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
            _navigationManager = navigationManager;
        }

        public void ExportOrgCostCentersToExcel(Query? query = null, string? fileName = null)
        {
            _navigationManager.NavigateTo(query != null ? query.ToUrl($"export/selfmanagement/orgcostcenters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/selfmanagement/orgcostcenters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public void ExportOrgCostCentersToCSV(Query? query = null, string? fileName = null)
        {
            _navigationManager.NavigateTo(query != null ? query.ToUrl($"export/selfmanagement/orgcostcenters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/selfmanagement/orgcostcenters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task<ODataServiceResult<OrgCostCenter>> GetOrgCostCenters(string? filter = default, int? top = default, int? skip = default, string? orderby = default, string? expand = default, string? select = default, bool? count = default)
        {
            var results = new ODataServiceResult<OrgCostCenter>();
            if (_httpClient == null) return results;

            var uri = new Uri($"{_httpClient.BaseAddress}odata/OrgCostCenters");
            uri = uri.GetODataUri(filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            if (response.IsSuccessStatusCode) 
            { 
                results = await response.ReadAsync<ODataServiceResult<OrgCostCenter>>();            
            }

            OnGet(results);
            return results;
        }

        public async Task<OrgCostCenter> GetOrgCostCenter(int id)
        {
            var result = new OrgCostCenter();
            if (_httpClient == null) return result;

            var response = await _httpClient.GetAsync($"/api/OrgCostCenters/{id}");
            if (response.IsSuccessStatusCode) 
            { 
                result = await response.ReadAsync<OrgCostCenter>();          
            }

            OnGetById(result);
            return result;
        }

        public async Task<OrgCostCenter> CreateOrgCostCenter(OrgCostCenter item)
        {
            OnCreated(item);

            var result = new OrgCostCenter();
            if (_httpClient == null) return result;

            var payload = new StringContent(ODataJsonSerializer.Serialize(item), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync("/api/OrgCostCenters", payload);
            if (response.IsSuccessStatusCode) 
            { 
                result = await response.ReadAsync<OrgCostCenter>();
            }

            AfterCreated(result);
            return result;
        }

        public async Task<OrgCostCenter> CancelOrgCostCenterChanges(OrgCostCenter item)
        {
            var result = new OrgCostCenter();
            if (_httpClient == null) return result;

            var payload = new StringContent(ODataJsonSerializer.Serialize(item), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync("/api/OrgCostCenters/Cancel", payload);
            if (response.IsSuccessStatusCode)
            {
                result = await response.ReadAsync<OrgCostCenter>();
            }

            return result;
        }

        public async Task<OrgCostCenter> UpdateOrgCostCenter(int id, OrgCostCenter entity)
        {
            OnUpdated(entity);

            var result = new OrgCostCenter();
            if (_httpClient == null) return result;

            var payload = new StringContent(ODataJsonSerializer.Serialize(entity), Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync($"/api/OrgCostCenters/{id}", payload);
            if (response.IsSuccessStatusCode)
            {
                result = await response.ReadAsync<OrgCostCenter>();
            }

            AfterUpdated(result);
            return result;
        }

        public async Task<OrgCostCenter> DeleteOrgCostCenter(int id)
        {
            var item = await GetOrgCostCenter(id);
            OnDeleted(item);

            if (_httpClient == null) return item;

            var response = await _httpClient.DeleteAsync($"/api/OrgCostCenters/{id}");
            response.EnsureSuccessStatusCode();

            AfterDeleted(item);
            return item;
        }
    }
}

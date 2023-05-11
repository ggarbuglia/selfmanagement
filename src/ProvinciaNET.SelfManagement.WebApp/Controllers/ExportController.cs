using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.WebApp.Services.Organization;
using ProvinciaNET.SelfManagement.WebApp.Services.Virtualization;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    /// <summary>
    /// Export Controller
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.WebApp.Controllers.ExcelExportController" />
    public class ExportController : ExcelExportController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NavigationManager _navigationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportController"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="navigationManager">The navigation manager.</param>
        public ExportController(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
        {
            _httpClientFactory = httpClientFactory;
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Exports the OrgCostCenter to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgCostCenters/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToCsv(string? fileName = null)
        {
            var service = new OrgCostCenterService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgCostCenter to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgCostCenters/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToXlsx(string? fileName = null)
        {
            var service = new OrgCostCenterService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgDirection to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgDirections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToCsv(string? fileName = null)
        {
            var service = new OrgDirectionService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgDirection to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgDirections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToXlsx(string? fileName = null)
        {
            var service = new OrgDirectionService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgLocation to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgLocations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgLocationsToCsv(string? fileName = null)
        {
            var service = new OrgLocationService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgLocation to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgLocations/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgLocationsToXlsx(string? fileName = null)
        {
            var service = new OrgLocationService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgMailDatabaseGroup to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMailDatabaseGroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMailDatabaseGroupsToCsv(string? fileName = null)
        {
            var service = new OrgMailDatabaseGroupService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgMailDatabaseGroup to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMailDatabaseGroups/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMailDatabaseGroupsToXlsx(string? fileName = null)
        {
            var service = new OrgMailDatabaseGroupService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgMembership to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMemberships/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMembershipsToCsv(string? fileName = null)
        {
            var service = new OrgMembershipService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgMembership to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMemberships/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMembershipsToXlsx(string? fileName = null)
        {
            var service = new OrgMembershipService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgSection to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgSections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToCsv(string? fileName = null)
        {
            var service = new OrgSectionService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgSection to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgSections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToXlsx(string? fileName = null)
        {
            var service = new OrgSectionService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgStructure to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgStructures/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgStructuresToCsv(string? fileName = null)
        {
            var service = new OrgStructureService(_httpClientFactory, _navigationManager);
            return ExportToCsv(await service.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the OrgStructure to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgStructures/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgStructuresToXlsx(string? fileName = null)
        {
            var service = new OrgStructureService(_httpClientFactory, _navigationManager);
            return ExportToXlsx(await service.GetAsync(), fileName);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.WebApp.Services;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    /// <summary>
    /// Export Controller
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.WebApp.Controllers.ExcelExportController" />
    public class ExportController : ExcelExportController
    {
        /// <summary>
        /// The org cost center service
        /// </summary>
        protected readonly IOrgCostCenterService _orgCostCenterService;

        /// <summary>
        /// The org direction service
        /// </summary>
        protected readonly IOrgDirectionService _orgDirectionService;

        /// <summary>
        /// The org location service
        /// </summary>
        protected readonly IOrgLocationService _orgLocationService;

        /// <summary>
        /// The org mail database group service
        /// </summary>
        protected readonly IOrgMailDatabaseGroupService _orgMailDatabaseGroupService;

        /// <summary>
        /// The org membership service
        /// </summary>
        protected readonly IOrgMembershipService _orgMembershipService;

        /// <summary>
        /// The org section service
        /// </summary>
        protected readonly IOrgSectionService _orgSectionService;

        /// <summary>
        /// The org structure service
        /// </summary>
        protected readonly IOrgStructureService _orgStructureService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportController"/> class.
        /// </summary>
        /// <param name="orgCostCenterService">The org cost center service.</param>
        /// <param name="orgDirectionService">The org direction service.</param>
        /// <param name="orgLocationService">The org location service.</param>
        /// <param name="orgMailDatabaseGroupService">The org mail database group service.</param>
        /// <param name="orgMembershipService">The org membership service.</param>
        /// <param name="orgSectionService">The org section service.</param>
        /// <param name="orgStructureService">The org structure service.</param>
        public ExportController(
            IOrgCostCenterService orgCostCenterService,
            IOrgDirectionService orgDirectionService,
            IOrgLocationService orgLocationService,
            IOrgMailDatabaseGroupService orgMailDatabaseGroupService,
            IOrgMembershipService orgMembershipService,
            IOrgSectionService orgSectionService,
            IOrgStructureService orgStructureService
            )
        {
            _orgCostCenterService = orgCostCenterService;
            _orgDirectionService = orgDirectionService;
            _orgLocationService = orgLocationService;
            _orgMailDatabaseGroupService = orgMailDatabaseGroupService;
            _orgMembershipService = orgMembershipService;
            _orgSectionService = orgSectionService;
            _orgStructureService = orgStructureService;
        }

        /// <summary>
        /// Exports the org cost centers to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgCostCenters/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgCostCenterService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org cost centers to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgCostCenters/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgCostCenterService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org directions to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgDirections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgDirectionService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org directions to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgDirections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgDirectionService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgSections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgSectionService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgSections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgSectionService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgLocations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgLocationsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgLocationService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgLocations/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgLocationsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgLocationService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMailDatabaseGroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMailDatabaseGroupsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgMailDatabaseGroupService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMailDatabaseGroups/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMailDatabaseGroupsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgMailDatabaseGroupService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMemberships/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMembershipsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgMembershipService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgMemberships/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgMembershipsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgMembershipService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to CSV.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgStructures/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgStructuresToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgStructureService.GetAsync(), fileName);
        }

        /// <summary>
        /// Exports the org sections to XLSX.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet("/export/OrgStructures/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgStructuresToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgStructureService.GetAsync(), fileName);
        }
    }
}
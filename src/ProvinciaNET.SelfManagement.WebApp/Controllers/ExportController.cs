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
        /// The org section service
        /// </summary>
        protected readonly IOrgSectionService _orgSectionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportController"/> class.
        /// </summary>
        /// <param name="orgCostCenterService">The org cost center service.</param>
        /// <param name="orgDirectionService">The org direction service.</param>
        /// <param name="orgSectionService">The org section service.</param>
        public ExportController(
            IOrgCostCenterService orgCostCenterService,
            IOrgDirectionService orgDirectionService,
            IOrgSectionService orgSectionService
            )
        {
            _orgCostCenterService = orgCostCenterService;
            _orgDirectionService = orgDirectionService;
            _orgSectionService = orgSectionService;
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
    }
}
using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.WebApp.Services;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    public class ExportController : ExcelExportController
    {
        protected readonly IOrgCostCenterService _orgCostCenterService;
        protected readonly IOrgDirectionService _orgDirectionService;
        protected readonly IOrgSectionService _orgSectionService;

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

        [HttpGet("/export/OrgCostCenters/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgCostCenterService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgCostCenters/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgCostCenterService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgDirections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgDirectionService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgDirections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgDirectionsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgDirectionService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgSections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgSectionService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgSections/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgSectionsToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgSectionService.GetAsync(), fileName);
        }
    }
}
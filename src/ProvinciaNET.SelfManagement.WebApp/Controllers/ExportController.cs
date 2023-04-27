using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.WebApp.Services;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    public class ExportController : ExcelExportController
    {
        protected readonly ISelfManagementWebApiService _orgCostCenterService;

        public ExportController(OrgCostCenterService orgCostCenterService)
        {
            _orgCostCenterService = orgCostCenterService;
        }

        [HttpGet("/export/OrgCostCenters/csv")]
        [HttpGet("/export/OrgCostCenters/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToCsv(string? fileName = null)
        {
            return ExportToCsv(await _orgCostCenterService.GetAsync(), fileName);
        }

        [HttpGet("/export/OrgCostCenters/xlsx")]
        [HttpGet("/export/OrgCostCenters/xlsx(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOrgCostCentersToXlsx(string? fileName = null)
        {
            return ExportToXlsx(await _orgCostCenterService.GetAsync(), fileName);
        }
    }
}

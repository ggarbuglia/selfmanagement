using CodegenCS;
using CodegenCS.IO;

namespace ProvinciaNET.SelfManagement.WebApp.Templates
{
    /// <summary>
    /// Expoert Controller Template
    /// </summary>
    public class ExportControllerTemplate
    {
        public void Main()
        {
            var classTypes = new string[] {
                //"AdUserAccount",
                //"AdUserAccountProvision",
                "OrgCostCenter",
                "OrgDirection",
                "OrgLocation",
                "OrgMailDatabaseGroup",
                "OrgMembership",
                "OrgSection",
                "OrgStructure"

                //"VirCategoryTag",
                //"VirCluster",
                //"VirDataCenter",
                //"VirDataStore",
                //"VirNetwork",
                //"VirOperatingSystemType",
                //"VirResource",
                //"VirtualMachine"
            };

            var w = new CodegenTextWriter();
            w.WriteLine(ControllerHeaderTemplate());
            foreach (var classType in classTypes) w.WriteLine(ControllerMethods(classType));
            w.WriteLine(ControllerFooterTemplate());
            w.SaveToFile("ExportController.cs");
        }

        static FormattableString ControllerHeaderTemplate() => $$"""
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

            """;

        static FormattableString ControllerFooterTemplate() => $$"""
                }
            }
            """;

        static FormattableString ControllerMethods(string classType) => $$"""
                    /// <summary>
                    /// Exports the {{classType}} to CSV.
                    /// </summary>
                    /// <param name="fileName">Name of the file.</param>
                    /// <returns></returns>
                    [HttpGet("/export/{{classType}}s/csv(fileName='{fileName}')")]
                    public async Task<FileStreamResult> Export{{classType}}sToCsv(string? fileName = null)
                    {
                        var service = new {{classType}}Service(_httpClientFactory, _navigationManager);
                        return ExportToCsv(await service.GetAsync(), fileName);
                    }
            
                    /// <summary>
                    /// Exports the {{classType}} to XLSX.
                    /// </summary>
                    /// <param name="fileName">Name of the file.</param>
                    /// <returns></returns>
                    [HttpGet("/export/{{classType}}s/xlsx(fileName='{fileName}')")]
                    public async Task<FileStreamResult> Export{{classType}}sToXlsx(string? fileName = null)
                    {
                        var service = new {{classType}}Service(_httpClientFactory, _navigationManager);
                        return ExportToXlsx(await service.GetAsync(), fileName);
                    }

            """;
    }
}
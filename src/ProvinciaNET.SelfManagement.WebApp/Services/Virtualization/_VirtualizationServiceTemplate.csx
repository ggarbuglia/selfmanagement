using CodegenCS;
using CodegenCS.IO;

namespace ProvinciaNET.SelfManagement.WebApp.Templates
{
    public class VirtualizationServiceTemplate
    {
        /// <summary>
        /// Mains the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Main(ICodegenContext context)
        {
            var classTypes = new string[] {
                "VirCategoryTag",
                "VirCluster",
                "VirDataCenter",
                "VirDataStore",
                "VirNetwork",
                "VirOperatingSystemType",
                "VirResource",
                "VirtualMachine"
            };

            foreach (var entity in entities)
            {
                var outputFile = context[$"{classType}sService.cs"];
                outputFile.WriteLine(ServiceTemplate(classType));
            }
        }

        /// <summary>
        /// Services the template.
        /// </summary>
        /// <param name="classType">The Class Type.</param>
        /// <returns></returns>
        static FormattableString ServiceTemplate(string classType) => $$"""
            using Microsoft.AspNetCore.Components;
            using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;

            namespace ProvinciaNET.SelfManagement.WebApp.Services.Virtualization
            {
                /// <summary>
                /// {{classType}} Service
                /// </summary>
                /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.WebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.{{classType}}&gt;" />
                /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApp.Services.IWebApiServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.{{classType}}&gt;" />
                public partial class {{classType}}Service : WebApiServiceBase<{{classType}}>, IWebApiServiceBase<{{classType}}>
                {
                    private readonly HttpClient _httpClient;
                    private readonly NavigationManager _navigationManager;

                    /// <summary>
                    /// Initializes a new instance of the <see cref="{{classType}}Service"/> class.
                    /// </summary>
                    /// <param name="httpClientFactory">The HTTP client factory.</param>
                    /// <param name="navigationManager">The navigation manager.</param>
                    public {{classType}}Service(IHttpClientFactory httpClientFactory, NavigationManager navigationManager)
                        : base(httpClientFactory, navigationManager)
                    {
                        _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
                        _navigationManager = navigationManager;
                    }
                }
            }
            """;
    }
}
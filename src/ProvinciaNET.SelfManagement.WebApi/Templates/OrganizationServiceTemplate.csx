using CodegenCS;
using CodegenCS.IO;

namespace ProvinciaNET.SelfManagement.WebApi.Templates
{
    /// <summary>
    /// Organization Service Template
    /// </summary>
    public class OrganizationServiceTemplate
    {
        /// <summary>
        /// Mains the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Main(ICodegenContext context)
        {
            var outputFolder = @"C:\Workspace\SelfManagement\src\ProvinciaNET.SelfManagement.WebApi\Templates";
            var assemblyNsmp = "ProvinciaNET.SelfManagement.Core.Entities.Organization";

            var entities = new string[] {
                "AdUserAccount",
                "AdUserAccountProvision",
                "OrgCostCenter",
                "OrgDirection",
                "OrgLocation",
                "OrgMailDatabaseGroup",
                "OrgMembership",
                "OrgSection",
                "OrgStructure"
            };

            foreach (var entity in entities)
            {
                var outputFile = context[$"{entity}sService.txt"];
                outputFile.WriteLine(ServiceTemplate(assemblyNsmp, entity));
            }

            context.SaveToFolder(outputFolder);
        }

        /// <summary>
        /// Services the template.
        /// </summary>
        /// <param name="assnmsp">The assnmsp.</param>
        /// <param name="clsn">The CLSN.</param>
        /// <returns></returns>
        static FormattableString ServiceTemplate(string assnmsp, string clsn) => $$"""
            using {{assnmsp}};
            using ProvinciaNET.SelfManagement.Infraestructure.Data;

            namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
            {
                /// <summary>
                /// {{clsn}}s Service
                /// </summary>
                /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;{{assnmsp}}.{{clsn}}&gt;" />
                /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;{{assnmsp}}.{{clsn}}&gt;" />
                public class {{clsn}}sService : CrudServiceBase<{{clsn}}>, ICrudServiceBase<{{clsn}}>
                {
                    private readonly SelfManagementContext _context;
                    private readonly ILogger<{{clsn}}sService> _logger;

                    /// <summary>
                    /// Initializes a new instance of the <see cref="{{clsn}}sService"/> class.
                    /// </summary>
                    /// <param name="context">The context.</param>
                    /// <param name="logger">The logger.</param>
                    public {{clsn}}sService(SelfManagementContext context, ILogger<{{clsn}}sService> logger)
                        : base(context, logger)
                    {
                        _context = context;
                        _logger = logger;
                    }
                }
            }
            """;
    }
}

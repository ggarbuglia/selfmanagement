using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// AdUserAccountProvisions Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.AdUserAccountProvision&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.AdUserAccountProvision&gt;" />
    public class AdUserAccountProvisionsService : CrudServiceBase<AdUserAccountProvision>, ICrudServiceBase<AdUserAccountProvision>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<AdUserAccountProvisionsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdUserAccountProvisionsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public AdUserAccountProvisionsService(SelfManagementContext context, ILogger<AdUserAccountProvisionsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
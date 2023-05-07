using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirResources Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirResource&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirResource&gt;" />
    public class VirResourcesService : CrudServiceBase<VirResource>, ICrudServiceBase<VirResource>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirResourcesService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirResourcesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirResourcesService(SelfManagementContext context, ILogger<VirResourcesService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
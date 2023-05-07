using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirNetworks Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirNetwork&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirNetwork&gt;" />
    public class VirNetworksService : CrudServiceBase<VirNetwork>, ICrudServiceBase<VirNetwork>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirNetworksService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirNetworksService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirNetworksService(SelfManagementContext context, ILogger<VirNetworksService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
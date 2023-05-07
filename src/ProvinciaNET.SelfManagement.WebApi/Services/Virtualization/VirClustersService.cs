using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirClusters Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCluster&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCluster&gt;" />
    public class VirClustersService : CrudServiceBase<VirCluster>, ICrudServiceBase<VirCluster>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirClustersService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirClustersService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirClustersService(SelfManagementContext context, ILogger<VirClustersService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
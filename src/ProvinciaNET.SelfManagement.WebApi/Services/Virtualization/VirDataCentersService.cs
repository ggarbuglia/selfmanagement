using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirDataCenters Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataCenter&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataCenter&gt;" />
    public class VirDataCentersService : CrudServiceBase<VirDataCenter>, ICrudServiceBase<VirDataCenter>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirDataCentersService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirDataCentersService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirDataCentersService(SelfManagementContext context, ILogger<VirDataCentersService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
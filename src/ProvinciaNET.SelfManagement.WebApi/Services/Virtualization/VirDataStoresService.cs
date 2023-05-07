using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirDataStores Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataStore&gt;" />
    /// <seealso typeparamref="ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirDataStore&gt;" />
    public class VirDataStoresService : CrudServiceBase<VirDataStore>, ICrudServiceBase<VirDataStore>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirDataStoresService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirDataStoresService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirDataStoresService(SelfManagementContext context, ILogger<VirDataStoresService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
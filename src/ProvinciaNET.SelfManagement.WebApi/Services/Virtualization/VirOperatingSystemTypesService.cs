using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirOperatingSystemTypes Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirOperatingSystemType&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirOperatingSystemType&gt;" />
    public class VirOperatingSystemTypesService : CrudServiceBase<VirOperatingSystemType>, ICrudServiceBase<VirOperatingSystemType>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirOperatingSystemTypesService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirOperatingSystemTypesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirOperatingSystemTypesService(SelfManagementContext context, ILogger<VirOperatingSystemTypesService> logger)
             : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
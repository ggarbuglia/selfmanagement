using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirtualMachines Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirtualMachine&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirtualMachine&gt;" />
    public class VirtualMachinesService : CrudServiceBase<VirtualMachine>, ICrudServiceBase<VirtualMachine>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirtualMachinesService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirtualMachinesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirtualMachinesService(SelfManagementContext context, ILogger<VirtualMachinesService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
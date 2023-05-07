using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgCostCenters Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgCostCenter&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgCostCenter&gt;" />
    public class OrgCostCentersService : CrudServiceBase<OrgCostCenter>, ICrudServiceBase<OrgCostCenter>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgCostCentersService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgCostCentersService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgCostCentersService(SelfManagementContext context, ILogger<OrgCostCentersService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgCostCenters.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgCostCenter>> Get()
        {
            var result = await _context
                .OrgCostCenters
                .Include(i => i.Sections)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgCostCenter specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgCostCenter?> Get(int id)
        {
            return await _context
                .OrgCostCenters
                .Include(i => i.Sections)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
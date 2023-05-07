using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgMemberships Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMembership&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMembership&gt;" />
    public class OrgMembershipsService : CrudServiceBase<OrgMembership>, ICrudServiceBase<OrgMembership>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgMembershipsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgMembershipsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgMembershipsService(SelfManagementContext context, ILogger<OrgMembershipsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgMemberships.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgMembership>> Get()
        {
            var result = await _context
                .OrgMemberships
                .Include(i => i.Structure)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgMembership specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgMembership?> Get(int id)
        {
            return await _context
                .OrgMemberships
                .Include(i => i.Structure)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgLocations Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgLocation&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgLocation&gt;" />
    public class OrgLocationsService : CrudServiceBase<OrgLocation>, ICrudServiceBase<OrgLocation>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgLocationsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgLocationsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgLocationsService(SelfManagementContext context, ILogger<OrgLocationsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgLocations.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgLocation>> Get()
        {
            var result = await _context
                .OrgLocations
                .Include(i => i.AdUserAccounts)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgLocation specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgLocation?> Get(int id)
        {
            return await _context
                .OrgLocations
                .Include(i => i.AdUserAccounts)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
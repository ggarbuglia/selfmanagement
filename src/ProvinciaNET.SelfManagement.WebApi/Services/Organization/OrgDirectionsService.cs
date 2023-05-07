using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgDirections Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgDirection&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgDirection&gt;" />
    public class OrgDirectionsService : CrudServiceBase<OrgDirection>, ICrudServiceBase<OrgDirection>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgDirectionsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgDirectionsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgDirectionsService(SelfManagementContext context, ILogger<OrgDirectionsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgDirections.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgDirection>> Get()
        {
            var result = await _context
                .OrgDirections
                .Include(i => i.Sections)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgDirection specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgDirection?> Get(int id)
        {
            return await _context
                .OrgDirections
                .Include(i => i.Sections)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
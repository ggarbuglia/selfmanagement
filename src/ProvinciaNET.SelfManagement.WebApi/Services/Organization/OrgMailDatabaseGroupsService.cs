using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgMailDatabaseGroups Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMailDatabaseGroup&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgMailDatabaseGroup&gt;" />
    public class OrgMailDatabaseGroupsService : CrudServiceBase<OrgMailDatabaseGroup>, ICrudServiceBase<OrgMailDatabaseGroup>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgMailDatabaseGroupsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgMailDatabaseGroupsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgMailDatabaseGroupsService(SelfManagementContext context, ILogger<OrgMailDatabaseGroupsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgMailDatabaseGroups.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgMailDatabaseGroup>> Get()
        {
            var result = await _context
                .OrgMailDatabaseGroups
                .Include(i => i.Structures)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgMailDatabaseGroup specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgMailDatabaseGroup?> Get(int id)
        {
            return await _context
                .OrgMailDatabaseGroups
                .Include(i => i.Structures)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
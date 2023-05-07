using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgStructures Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgStructure&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgStructure&gt;" />
    public class OrgStructuresService : CrudServiceBase<OrgStructure>, ICrudServiceBase<OrgStructure>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgStructuresService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgStructuresService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgStructuresService(SelfManagementContext context, ILogger<OrgStructuresService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgStructures.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgStructure>> Get()
        {
            var result = await _context
                .OrgStructures
                .Include(i => i.Section)
                .Include(i => i.MailDatabaseGroup)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgStructure specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgStructure?> Get(int id)
        {
            return await _context
                .OrgStructures
                .Include(i => i.Section)
                .Include(i => i.MailDatabaseGroup)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
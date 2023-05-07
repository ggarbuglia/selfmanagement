using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// OrgSections Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgSection&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.OrgSection&gt;" />
    public class OrgSectionsService : CrudServiceBase<OrgSection>, ICrudServiceBase<OrgSection>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgSectionsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgSectionsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgSectionsService(SelfManagementContext context, ILogger<OrgSectionsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all OrgSections.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<OrgSection>> Get()
        {
            var result = await _context
                .OrgSections
                .Include(i => i.CostCenter)
                .Include(i => i.Direction)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgSection specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<OrgSection?> Get(int id)
        {
            return await _context
                .OrgSections
                .Include(i => i.CostCenter)
                .Include(i => i.Direction)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
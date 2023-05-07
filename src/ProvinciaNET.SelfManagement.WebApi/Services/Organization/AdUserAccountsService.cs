using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// AdUserAccounts Service
    /// </summary>
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.AdUserAccount&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Organization.AdUserAccount&gt;" />
    public class AdUserAccountsService : CrudServiceBase<AdUserAccount>, ICrudServiceBase<AdUserAccount>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<AdUserAccountsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdUserAccountsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public AdUserAccountsService(SelfManagementContext context, ILogger<AdUserAccountsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all AdUserAccounts.
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<AdUserAccount>> Get()
        {
            var result = await _context
                .AdUserAccounts
                .Include(i => i.AdUserAccountProvisions)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a AdUserAccount specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<AdUserAccount?> Get(int id)
        {
            return await _context
                .AdUserAccounts
                .Include(i => i.AdUserAccountProvisions)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
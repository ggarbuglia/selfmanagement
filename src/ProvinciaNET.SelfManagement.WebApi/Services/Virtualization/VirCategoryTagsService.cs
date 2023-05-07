using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirCategoryTags Service
    /// </summary>
    /// <seealso typeramaref="ProvinciaNET.SelfManagement.WebApi.Services.CrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCategoryTag&gt;" />
    /// <seealso typeparamref="ProvinciaNET.SelfManagement.WebApi.Interfaces.ICrudServiceBase&lt;ProvinciaNET.SelfManagement.Core.Entities.Virtualization.VirCategoryTag&gt;" />
    public class VirCategoryTagsService : CrudServiceBase<VirCategoryTag>, ICrudServiceBase<VirCategoryTag>
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirCategoryTagsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see typeparamref="VirCategoryTagsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirCategoryTagsService(SelfManagementContext context, ILogger<VirCategoryTagsService> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
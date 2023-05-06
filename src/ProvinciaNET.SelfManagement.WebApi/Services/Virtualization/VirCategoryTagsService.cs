using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Interfaces.Virtualization;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Virtualization
{
    /// <summary>
    /// VirCategoryTags Service
    /// </summary>
    /// <seealso cref="IVirCategoryTagsService" />
    public class VirCategoryTagsService : IVirCategoryTagsService
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<VirCategoryTagsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirCategoryTagsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public VirCategoryTagsService(SelfManagementContext context, ILogger<VirCategoryTagsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all VirCategoryTags.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VirCategoryTag>> Get()
        {
            var result = await _context.VirCategoryTags.AsNoTracking().ToListAsync();
            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a VirCategoryTag specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<VirCategoryTag?> Get(int id)
        {
            return await _context.VirCategoryTags.FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Creates the specified resource.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<VirCategoryTag> Post(VirCategoryTag entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = null;
            entity.ModifiedBy = null;

            try
            {
                _logger.LogInformation("Creating resource.");

                _context.VirCategoryTags.Add(entity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Resource created with Id {id}.", entity.Id);
            }
            catch (Exception ex)
            {
                _context.Entry(entity).State = EntityState.Detached;
                _logger.LogError(ex, "{msg}", ex.Message);
                throw;
            }

            return entity;
        }

        /// <summary>
        /// Updates the resource specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public async Task Put(int id, VirCategoryTag entity)
        {
            var existing = await _context.VirCategoryTags.FirstAsync(o => o.Id == id);

            entity.ModifiedOn = DateTime.Now;

            try
            {
                _logger.LogInformation("Updating resource.");

                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Resource updated with Id {id}.", entity.Id);
            }
            catch (Exception ex)
            {
                _context.Entry(existing).State = EntityState.Unchanged;
                _logger.LogError(ex, "{msg}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Deletes the resource specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(int id)
        {
            var entity = await _context.VirCategoryTags.FirstAsync(o => o.Id == id);

            try
            {
                _logger.LogInformation("Deleting resource.");

                _context.VirCategoryTags.Remove(entity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Resource deleted with Id {id}.", id);
            }
            catch (Exception ex)
            {
                _context.Entry(entity).State = EntityState.Unchanged;
                _logger.LogError(ex, "{msg}", ex.Message);
                throw;
            }
        }
    }
}
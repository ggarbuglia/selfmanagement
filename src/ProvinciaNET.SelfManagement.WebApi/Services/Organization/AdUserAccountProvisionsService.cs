using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Interfaces.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.Services.Organization
{
    /// <summary>
    /// AdUserAccountProvisions Service
    /// </summary>
    /// <seealso cref="IAdUserAccountProvisionsService" />
    public class AdUserAccountProvisionsService : IAdUserAccountProvisionsService
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<AdUserAccountProvisionsService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdUserAccountProvisionsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public AdUserAccountProvisionsService(SelfManagementContext context, ILogger<AdUserAccountProvisionsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets all AdUserAccountProvisions.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AdUserAccountProvision>> Get()
        {
            var result = await _context.AdUserAccountProvisions.AsNoTracking().ToListAsync();
            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a AdUserAccountProvision specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<AdUserAccountProvision?> Get(int id)
        {
            return await _context.AdUserAccountProvisions.FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Creates the specified resource.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<AdUserAccountProvision> Post(AdUserAccountProvision entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = null;
            entity.ModifiedBy = null;

            try
            {
                _logger.LogInformation("Creating resource.");

                _context.AdUserAccountProvisions.Add(entity);
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
        public async Task Put(int id, AdUserAccountProvision entity)
        {
            var existing = await _context.AdUserAccountProvisions.FirstAsync(o => o.Id == id);

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
            var entity = await _context.AdUserAccountProvisions.FirstAsync(o => o.Id == id);

            try
            {
                _logger.LogInformation("Deleting resource.");

                _context.AdUserAccountProvisions.Remove(entity);
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
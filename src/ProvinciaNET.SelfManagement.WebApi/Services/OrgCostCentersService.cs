using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Interfaces;

namespace ProvinciaNET.SelfManagement.WebApi.Services
{
    /// <summary>
    /// OrgCostCenters Service
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.WebApi.Interfaces.IOrgCostCentersService" />
    public class OrgCostCentersService : IOrgCostCentersService
    {
        private readonly SelfManagementContext _context;
        private readonly ILogger<OrgCostCentersService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgCostCentersService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrgCostCentersService(SelfManagementContext context, ILogger<OrgCostCentersService> logger)
        {
            _context = context;
            _logger  = logger;
        }

        /// <summary>
        /// Gets all OrgCostCenters.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrgCostCenter>> Get()
        {
            var result = await _context.OrgCostCenters.Include(i => i.Sections).AsNoTracking().ToListAsync();
            _logger.LogInformation("Query Count: {count}", result.Count);
            return result;
        }

        /// <summary>
        /// Gets a OrgCostCenter specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<OrgCostCenter?> Get(int id)
        {
            return await _context.OrgCostCenters.Include(i => i.Sections).FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Creates the specified entity resource.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<OrgCostCenter> Post(OrgCostCenter entity)
        {
            entity.CreatedOn  = DateTime.Now;
            entity.ModifiedOn = null;
            entity.ModifiedBy = null;

            try
            {
                _logger.LogInformation("Creating resource.");

                _context.OrgCostCenters.Add(entity);
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
        /// Updates the entity resource specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public async Task Put(int id, OrgCostCenter entity)
        {
            var existing = await _context.OrgCostCenters.FirstAsync(o => o.Id == id);

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
        /// Deletes the entity resource specified by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(int id)
        {
            var entity = await _context.OrgCostCenters.FirstAsync(o => o.Id == id);

            try
            {
                _logger.LogInformation("Deleting resource.");

                _context.OrgCostCenters.Remove(entity);
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.WebApi.Helpers
{
    public class WebApiActionsBaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly ILogger _logger;

        private readonly DbSet<T> _dbSet;
        private readonly string _dbSetTypeName;
        private readonly string _entityTypeName;

        public WebApiActionsBaseController(DbContext context, ILogger<WebApiActionsBaseController<T>> logger)
        {
            _context = context;
            _logger  = logger;

            _dbSet          = _context.Set<T>();
            _dbSetTypeName  = _dbSet.GetType().Name;
            _entityTypeName = typeof(T).Name;
        }

        [NonAction]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            if (_dbSet == null)
            {
                _logger.LogWarning("Entity Set '{type}' is null.", _dbSetTypeName);
                return NotFound();
            }

            var result = await _dbSet.AsNoTracking().ToListAsync();

            _logger.LogInformation("Query Count: {type} {count}", _entityTypeName, result.Count);
            return result;
        }

        [NonAction]
        public async Task<ActionResult<T>> Get(int id)
        {
            if (_dbSet == null)
            {
                _logger.LogWarning("Entity Set '{type}' is null.", _dbSetTypeName);
                return NotFound();
            }

            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                _logger.LogWarning("Entity '{type}' with Id {id} not found.", _entityTypeName, id);
                return NotFound();
            }

            return entity;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [NonAction]
        public async Task<IActionResult> Put(int id, T entity)
        {
            if (id != entity.Id)
            {
                _logger.LogError("Ids dont match. Param Id: {id1} Entity Id: {id2}.", id, entity.Id);
                return BadRequest();
            }

            entity.ModifiedOn = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _logger.LogInformation("Saving changes to database.");
                await _context.SaveChangesAsync();
                _logger.LogInformation("Changes saved.");
            }
            catch (DbUpdateConcurrencyException dbce)
            {
                _logger.LogError("Exception ocurred!");

                if (!EntityExists(id))
                {
                    _logger.LogWarning("Entity '{type}' with Id {id} not found.", _entityTypeName, id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(dbce, "{msg}", dbce.Message);
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [NonAction]
        public async Task<ActionResult<T>> Post(string action, T entity)
        {
            if (_dbSet == null)
            {
                _logger.LogWarning("Entity Set '{type}' is null.", _dbSetTypeName);
                return Problem($"Entity Set '{_dbSetTypeName}' is null.");
            }

            var now = DateTime.Now;
            entity.CreatedOn = now;
            entity.ModifiedOn = now;
            entity.ModifiedBy = string.Empty;
            _dbSet.Add(entity);

            _logger.LogInformation("Saving changes to database.");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Changes saved.");

            return CreatedAtAction(action, new { id = entity.Id }, entity);
        }

        [NonAction]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbSet == null)
            {
                _logger.LogWarning("Entity Set '{type}' is null.", _dbSetTypeName);
                return NotFound();
            }

            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                _logger.LogWarning("Entity '{type}' with Id {id} not found.", _entityTypeName, id);
                return NotFound();
            }

            _dbSet.Remove(entity);

            _logger.LogInformation("Saving changes to database.");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Changes saved.");

            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return (_dbSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

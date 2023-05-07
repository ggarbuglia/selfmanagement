using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using ProvinciaNET.SelfManagement.WebApi.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers.Organization
{
    /// <summary>
    /// OrgStructures Controller
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController, ApiKey]
    [SwaggerTag("Organization")]
    public class OrgStructuresController : ControllerBase
    {
        private readonly ILogger<OrgStructuresController> _logger;
        private readonly ICrudServiceBase<OrgStructure> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrgStructuresController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="service">The service.</param>
        public OrgStructuresController(ILogger<OrgStructuresController> logger, ICrudServiceBase<OrgStructure> service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Gets all 'OrgStructure' resources.
        /// </summary>
        /// <returns></returns>
        [HttpGet, EnableQuery(PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrgStructure))]
        public async Task<ActionResult<IEnumerable<OrgStructure>>> GetOrgStructures()
        {
            var entities = await _service.Get();
            return Ok(entities);
        }

        /// <summary>
        /// Gets a 'OrgStructure' resource by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}"), ODataIgnored]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrgStructure))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrgStructure?>> GetOrgStructure(int id)
        {
            var entity = await _service.Get(id);
            if (entity == null)
            {
                _logger.LogWarning("Entity 'OrgStructure' with Id {id} not found.", id);
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Creates a 'OrgStructure' resource.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost, ODataIgnored]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrgStructure), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrgStructure>> PostOrgStructure(OrgStructure entity)
        {
            if (_service.Get(entity.Id).Result != null)
            {
                _logger.LogWarning("Entity 'OrgStructure' with Id {id} already exists.", entity.Id);
                return BadRequest();
            }

            try
            {
                entity = await _service.Post(entity);
            }
            catch (Exception ex)
            {
                return Problem($"Error while creating resource: {ex.Message}");
            }

            return CreatedAtAction("GetOrgStructure", new { id = entity.Id }, entity);
        }

        /// <summary>
        /// Updates a 'OrgStructure' resource by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPut("{id}"), ODataIgnored]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutOrgStructure(int id, OrgStructure entity)
        {
            if (id != entity.Id)
            {
                _logger.LogError("Ids dont match. Param Id: {id1} Entity Id: {id2}.", id, entity.Id);
                return BadRequest();
            }

            var existing = await _service.Get(id);
            if (existing == null)
            {
                _logger.LogWarning("Entity 'OrgStructure' with Id {id} not found.", id);
                return NotFound();
            }

            try
            {
                await _service.Put(id, entity);
            }
            catch (Exception ex)
            {
                return Problem($"Error while updating resource: {ex.Message}");
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a 'OrgStructure' resource by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ODataIgnored]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteOrgStructure(int id)
        {
            var entity = await _service.Get(id);
            if (entity == null)
            {
                _logger.LogWarning("Entity 'OrgStructure' with Id {id} not found.", id);
                return NotFound();
            }

            try
            {
                await _service.Delete(id);
            }
            catch (Exception ex)
            {
                return Problem($"Error while deleting resource: {ex.Message}");
            }

            return NoContent();
        }
    }
}
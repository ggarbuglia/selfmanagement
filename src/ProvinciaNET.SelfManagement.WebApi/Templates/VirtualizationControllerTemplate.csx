using CodegenCS;
using CodegenCS.IO;

namespace ProvinciaNET.SelfManagement.WebApi.Templates
{
    /// <summary>
    /// Virtualization Controller Template
    /// </summary>
    public class VirtualizationControllerTemplate
    {
        /// <summary>
        /// Mains the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Main(ICodegenContext context)
        {
            var outputFolder = @"C:\Workspace\SelfManagement\src\ProvinciaNET.SelfManagement.WebApi\Templates";
            var assemblyNsmp = "ProvinciaNET.SelfManagement.Core.Entities.Virtualization";

            var entities = new string[] {
                "VirCategoryTag",
                "VirCluster",
                "VirDataCenter",
                "VirDataStore",
                "VirNetwork",
                "VirOperatingSystemType",
                "VirResource",
                "VirtualMachine"
            };

            foreach (var entity in entities)
            {
                var outputFile = context[$"{entity}sController.txt"];
                outputFile.WriteLine(ControllerTemplate(assemblyNsmp, entity));
            }

            context.SaveToFolder(outputFolder);
        }

        /// <summary>
        /// Controllers the template.
        /// </summary>
        /// <param name="assnmsp">The assnmsp.</param>
        /// <param name="clsn">The CLSN.</param>
        /// <returns></returns>
        static FormattableString ControllerTemplate(string assnmsp, string clsn) => $$"""
            using Microsoft.AspNetCore.Mvc;
            using Microsoft.AspNetCore.OData.Query;
            using Microsoft.AspNetCore.OData.Routing.Attributes;
            using {{assnmsp}};
            using ProvinciaNET.SelfManagement.WebApi.Helpers;
            using ProvinciaNET.SelfManagement.WebApi.Services;
            using Swashbuckle.AspNetCore.Annotations;
            using System.Net.Mime;

            namespace ProvinciaNET.SelfManagement.WebApi.Controllers.Virtualization
            {
                /// <summary>
                /// {{clsn}}s Controller
                /// </summary>
                /// <seealso cref="ControllerBase" />
                [Route("api/[controller]")]
                [ApiController, ApiKey]
                [SwaggerTag("Virtualization")]
                public class {{clsn}}sController : ControllerBase
                {
                    private readonly ILogger<{{clsn}}sController> _logger;
                    private readonly ICrudServiceBase<{{clsn}}> _service;

                    /// <summary>
                    /// Initializes a new instance of the <see cref="{{clsn}}sController"/> class.
                    /// </summary>
                    /// <param name="logger">The logger.</param>
                    /// <param name="service">The service.</param>
                    public {{clsn}}sController(ILogger<{{clsn}}sController> logger, ICrudServiceBase<{{clsn}}> service)
                    {
                        _logger = logger;
                        _service = service;
                    }

                    /// <summary>
                    /// Gets all '{{clsn}}' resources.
                    /// </summary>
                    /// <returns></returns>
                    [HttpGet, EnableQuery(PageSize = 1000)]
                    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof({{clsn}}))]
                    public async Task<ActionResult<IEnumerable<{{clsn}}>>> Get{{clsn}}s()
                    {
                        var entities = await _service.Get();
                        return Ok(entities);
                    }

                    /// <summary>
                    /// Gets a '{{clsn}}' resource by ID.
                    /// </summary>
                    /// <param name="id">The identifier.</param>
                    /// <returns></returns>
                    [HttpGet("{id}"), ODataIgnored]
                    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof({{clsn}}))]
                    [ProducesResponseType(StatusCodes.Status404NotFound)]
                    public async Task<ActionResult<{{clsn}}?>> Get{{clsn}}(int id)
                    {
                        var entity = await _service.Get(id);
                        if (entity == null)
                        {
                            _logger.LogWarning("Entity '{{clsn}}' with Id {id} not found.", id);
                            return NotFound();
                        }

                        return Ok(entity);
                    }

                    /// <summary>
                    /// Creates a '{{clsn}}' resource.
                    /// </summary>
                    /// <param name="entity">The entity.</param>
                    /// <returns></returns>
                    [HttpPost, ODataIgnored]
                    [Consumes(MediaTypeNames.Application.Json)]
                    [ProducesResponseType(typeof({{clsn}}), StatusCodes.Status201Created)]
                    [ProducesResponseType(StatusCodes.Status400BadRequest)]
                    public async Task<ActionResult<{{clsn}}>> Post{{clsn}}({{clsn}} entity)
                    {
                        if (_service.Get(entity.Id).Result != null)
                        {
                            _logger.LogWarning("Entity '{{clsn}}' with Id {id} already exists.", entity.Id);
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

                        return CreatedAtAction("Get{{clsn}}", new { id = entity.Id }, entity);
                    }

                    /// <summary>
                    /// Updates a '{{clsn}}' resource by ID.
                    /// </summary>
                    /// <param name="id">The identifier.</param>
                    /// <param name="entity">The entity.</param>
                    /// <returns></returns>
                    [HttpPut("{id}"), ODataIgnored]
                    [Consumes(MediaTypeNames.Application.Json)]
                    [ProducesResponseType(StatusCodes.Status400BadRequest)]
                    [ProducesResponseType(StatusCodes.Status404NotFound)]
                    [ProducesResponseType(StatusCodes.Status204NoContent)]
                    public async Task<IActionResult> Put{{clsn}}(int id, {{clsn}} entity)
                    {
                        if (id != entity.Id)
                        {
                            _logger.LogError("Ids dont match. Param Id: {id1} Entity Id: {id2}.", id, entity.Id);
                            return BadRequest();
                        }

                        var existing = await _service.Get(id);
                        if (existing == null)
                        {
                            _logger.LogWarning("Entity '{{clsn}}' with Id {id} not found.", id);
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
                    /// Deletes a '{{clsn}}' resource by ID.
                    /// </summary>
                    /// <param name="id">The identifier.</param>
                    /// <returns></returns>
                    [HttpDelete("{id}"), ODataIgnored]
                    [ProducesResponseType(StatusCodes.Status404NotFound)]
                    [ProducesResponseType(StatusCodes.Status204NoContent)]
                    public async Task<IActionResult> Delete{{clsn}}(int id)
                    {
                        var entity = await _service.Get(id);
                        if (entity == null)
                        {
                            _logger.LogWarning("Entity '{{clsn}}' with Id {id} not found.", id);
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
            """;
    }
}

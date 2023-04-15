using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Common.Context;
using ProvinciaNET.SelfManagement.Common.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgLocationsController : WebApiActionsBaseController<OrgLocation>
    {
        public OrgLocationsController(SelfManagementContext context, ILogger<OrgLocationsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgLocation>>> GetOrgLocations()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgLocation>> GetOrgLocation(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgLocation(int id, OrgLocation entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgLocation>> PostOrgLocation(OrgLocation entity)
        {
            return await Post("GetOrgLocation", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgLocation(int id)
        {
            return await Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Common.Context;
using ProvinciaNET.SelfManagement.Common.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgDirectionsController : WebApiActionsBaseController<OrgDirection>
    {
        public OrgDirectionsController(SelfManagementContext context, ILogger<OrgDirectionsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgDirection>>> GetOrgDirections()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgDirection>> GetOrgDirection(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgDirection(int id, OrgDirection entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgDirection>> PostOrgDirection(OrgDirection entity)
        {
            return await Post("GetOrgDirection", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgDirection(int id)
        {
            return await Delete(id);
        }
    }
}

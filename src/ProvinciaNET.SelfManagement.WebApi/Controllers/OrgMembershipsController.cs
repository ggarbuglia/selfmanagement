using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgMembershipsController : WebApiActionsBaseController<OrgMembership>
    {
        public OrgMembershipsController(DbContext context, ILogger<OrgMembershipsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet, EnableQuery(PageSize = 1000)]
        public async Task<ActionResult<IEnumerable<OrgMembership>>> GetOrgMemberships()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgMembership>> GetOrgMembership(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgMembership(int id, OrgMembership entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgMembership>> PostOrgMembership(OrgMembership entity)
        {
            return await Post("GetOrgMembership", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgMembership(int id)
        {
            return await Delete(id);
        }
    }
}

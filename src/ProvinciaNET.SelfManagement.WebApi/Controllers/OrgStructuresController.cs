using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Common.Context;
using ProvinciaNET.SelfManagement.Common.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgStructuresController : WebApiActionsBaseController<OrgStructure>
    {
        public OrgStructuresController(SelfManagementContext context, ILogger<OrgStructuresController> logger)
            : base(context, logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgStructure>>> GetOrgStructures()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgStructure>> GetOrgStructure(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgStructure(int id, OrgStructure entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgStructure>> PostOrgStructure(OrgStructure entity)
        {
            return await Post("GetOrgStructure", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgStructure(int id)
        {
            return await Delete(id);
        }
    }
}

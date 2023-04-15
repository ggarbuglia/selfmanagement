using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Common.Context;
using ProvinciaNET.SelfManagement.Common.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgSectionsController : WebApiActionsBaseController<OrgSection>
    {
        public OrgSectionsController(SelfManagementContext context, ILogger<OrgSectionsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgSection>>> GetOrgSections()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgSection>> GetOrgSection(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgSection(int id, OrgSection entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgSection>> PostOrgSection(OrgSection entity)
        {
            return await Post("GetOrgSection", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgSection(int id)
        {
            return await Delete(id);
        }
    }
}

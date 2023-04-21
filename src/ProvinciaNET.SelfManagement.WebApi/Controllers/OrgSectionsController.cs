using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgSectionsController : WebApiActionsBaseController<OrgSection>
    {
        public OrgSectionsController(DbContext context, ILogger<OrgSectionsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet, EnableQuery(PageSize = 1000)]
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

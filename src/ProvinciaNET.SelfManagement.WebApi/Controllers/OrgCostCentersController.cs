using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgCostCentersController : WebApiActionsBaseController<OrgCostCenter>
    {
        public OrgCostCentersController(DbContext context, ILogger<OrgCostCentersController> logger)
            : base(context, logger)
        {
        }

        [HttpGet, EnableQuery(PageSize=1000)]
        public async Task<ActionResult<IEnumerable<OrgCostCenter>>> GetOrgCostCenters()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgCostCenter>> GetOrgCostCenter(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgCostCenter(int id, OrgCostCenter entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgCostCenter>> PostOrgCostCenter(OrgCostCenter entity)
        {
            return await Post("GetOrgCostCenter", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgCostCenter(int id)
        {
            return await Delete(id);
        }
    }
}

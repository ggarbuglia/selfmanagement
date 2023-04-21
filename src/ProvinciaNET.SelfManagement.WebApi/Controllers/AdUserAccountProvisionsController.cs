using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdUserAccountProvisionsController : WebApiActionsBaseController<AdUserAccountProvision>
    {
        public AdUserAccountProvisionsController(DbContext context, ILogger<AdUserAccountProvisionsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet, EnableQuery(PageSize = 1000)]
        public async Task<ActionResult<IEnumerable<AdUserAccountProvision>>> GetAdUserAccountProvisions()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdUserAccountProvision>> GetAdUserAccountProvision(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdUserAccountProvision(int id, AdUserAccountProvision entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<AdUserAccountProvision>> PostAdUserAccountProvision(AdUserAccountProvision entity)
        {
            return await Post("GetAdUserAccountProvision", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdUserAccountProvision(int id)
        {
            return await Delete(id);
        }
    }
}

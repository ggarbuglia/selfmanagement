using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdUserAccountsController : WebApiActionsBaseController<AdUserAccount>
    {
        public AdUserAccountsController(DbContext context, ILogger<AdUserAccountsController> logger)
        : base(context, logger) 
        {
        }

        [HttpGet, EnableQuery(PageSize = 1000)]
        public async Task<ActionResult<IEnumerable<AdUserAccount>>> GetAdUserAccounts()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdUserAccount>> GetAdUserAccount(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdUserAccount(int id, AdUserAccount entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<AdUserAccount>> PostAdUserAccount(AdUserAccount entity)
        {
            return await Post("GetAdUserAccount", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdUserAccount(int id)
        {
            return await Delete(id);
        }
    }
}

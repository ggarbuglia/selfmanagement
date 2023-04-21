﻿using Microsoft.AspNetCore.Mvc;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ProvinciaNET.SelfManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgMailDatabaseGroupsController : WebApiActionsBaseController<OrgMailDatabaseGroup>
    {
        public OrgMailDatabaseGroupsController(DbContext context, ILogger<OrgMailDatabaseGroupsController> logger)
            : base(context, logger)
        {
        }

        [HttpGet, EnableQuery(PageSize = 1000)]
        public async Task<ActionResult<IEnumerable<OrgMailDatabaseGroup>>> GetOrgMailDatabaseGroups()
        {
            return await Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgMailDatabaseGroup>> GetOrgMailDatabaseGroup(int id)
        {
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgMailDatabaseGroup(int id, OrgMailDatabaseGroup entity)
        {
            return await Put(id, entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrgMailDatabaseGroup>> PostOrgMailDatabaseGroup(OrgMailDatabaseGroup entity)
        {
            return await Post("GetOrgMailDatabaseGroup", entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgMailDatabaseGroup(int id)
        {
            return await Delete(id);
        }
    }
}

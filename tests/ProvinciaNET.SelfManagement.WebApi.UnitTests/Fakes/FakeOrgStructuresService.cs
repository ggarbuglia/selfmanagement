using ProvinciaNET.SelfManagement.WebApi.Interfaces.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgStructuresService : IOrgStructuresService
    {
        private readonly List<OrgStructure> _items;

        public FakeOrgStructuresService()
        {
            _items = new List<OrgStructure>
            {
                new OrgStructure()
                {
                    Id = 1,
                    Group = "Group 1",
                    OrgUnit = "OrgUnit 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Section = new OrgSection(),
                    MailDatabaseGroup = new OrgMailDatabaseGroup()
                },

                new OrgStructure()
                {
                    Id = 2,
                    Group = "Group 2",
                    OrgUnit = "OrgUnit 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Section = new OrgSection(),
                    MailDatabaseGroup = new OrgMailDatabaseGroup()
                }
            };
        }

        public async Task<IEnumerable<OrgStructure>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgStructure?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgStructure> Post(OrgStructure entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgStructure entity)
        {
            var idx = _items.IndexOf(_items.First(o => o.Id == id));
            _items[idx] = entity;
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var idx = _items.IndexOf(_items.First(o => o.Id == id));
            _items.RemoveAt(idx);
            return Task.CompletedTask;
        }
    }
}
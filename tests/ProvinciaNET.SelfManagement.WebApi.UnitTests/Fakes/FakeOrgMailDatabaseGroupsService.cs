namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgMailDatabaseGroupsService : IOrgMailDatabaseGroupsService
    {
        private readonly List<OrgMailDatabaseGroup> _items;

        public FakeOrgMailDatabaseGroupsService()
        {
            _items = new List<OrgMailDatabaseGroup>
            {
                new OrgMailDatabaseGroup()
                {
                    Id = 1,
                    Name = "MailDatabaseGroup 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                },

                new OrgMailDatabaseGroup()
                {
                    Id = 2,
                    Name = "MailDatabaseGroup 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<OrgMailDatabaseGroup>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgMailDatabaseGroup?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgMailDatabaseGroup> Post(OrgMailDatabaseGroup entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgMailDatabaseGroup entity)
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
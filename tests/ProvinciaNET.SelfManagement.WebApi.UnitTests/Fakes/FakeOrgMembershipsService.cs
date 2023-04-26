namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgMembershipsService : IOrgMembershipsService
    {
        private readonly List<OrgMembership> _items;

        public FakeOrgMembershipsService()
        {
            _items = new List<OrgMembership>
            {
                new OrgMembership()
                {
                    Id = 1,
                    AdGroupDisplayName = "AdGroupDisplayName 1",
                    AdGroupAccountName = "AdGroupAccountName 1",
                    Show = true,
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Structure = new OrgStructure()
                },

                new OrgMembership()
                {
                    Id = 2,
                    AdGroupDisplayName = "AdGroupDisplayName 2",
                    AdGroupAccountName = "AdGroupAccountName 2",
                    Show = true,
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Structure = new OrgStructure()
                }
            };
        }

        public async Task<IEnumerable<OrgMembership>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgMembership?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgMembership> Post(OrgMembership entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgMembership entity)
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
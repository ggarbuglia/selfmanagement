using ProvinciaNET.SelfManagement.WebApi.Interfaces.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgCostCentersService : IOrgCostCentersService
    {
        private readonly List<OrgCostCenter> _items;

        public FakeOrgCostCentersService()
        {
            _items = new List<OrgCostCenter>
            {
                new OrgCostCenter()
                {
                    Id = 1,
                    Name = "CostCenter 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                },

                new OrgCostCenter()
                {
                    Id = 2,
                    Name = "CostCenter 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<OrgCostCenter>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgCostCenter?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgCostCenter> Post(OrgCostCenter entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgCostCenter entity)
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
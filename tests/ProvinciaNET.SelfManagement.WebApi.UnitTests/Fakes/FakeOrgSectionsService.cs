using ProvinciaNET.SelfManagement.WebApi.Interfaces.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgSectionsService : IOrgSectionsService
    {
        private readonly List<OrgSection> _items;

        public FakeOrgSectionsService()
        {
            _items = new List<OrgSection>
            {
                new OrgSection()
                {
                    Id = 1,
                    Name = "Section 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    CostCenter = new OrgCostCenter(),
                    Direction = new OrgDirection()
                },

                new OrgSection()
                {
                    Id = 2,
                    Name = "Section 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    CostCenter = new OrgCostCenter(),
                    Direction = new OrgDirection()
                }
            };
        }

        public async Task<IEnumerable<OrgSection>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgSection?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgSection> Post(OrgSection entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgSection entity)
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
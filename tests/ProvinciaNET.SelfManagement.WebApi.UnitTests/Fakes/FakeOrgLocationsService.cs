using ProvinciaNET.SelfManagement.WebApi.Interfaces.Organization;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgLocationsService : IOrgLocationsService
    {
        private readonly List<OrgLocation> _items;

        public FakeOrgLocationsService()
        {
            _items = new List<OrgLocation>
            {
                new OrgLocation()
                {
                    Id = 1,
                    Name = "Location 1",
                    Address = "Address 1",
                    PostalCode = "PostalCode 1",
                    City = "City 1",
                    AdGroupDisplayName = "AdGroupDisplayName 1",
                    AdGroupAccountName = "AdGroupAccountName 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                },

                new OrgLocation()
                {
                    Id = 2,
                    Name = "Location 2",
                    Address = "Address 2",
                    PostalCode = "PostalCode 2",
                    City = "City 2",
                    AdGroupDisplayName = "AdGroupDisplayName 2",
                    AdGroupAccountName = "AdGroupAccountName 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<OrgLocation>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgLocation?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgLocation> Post(OrgLocation entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgLocation entity)
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
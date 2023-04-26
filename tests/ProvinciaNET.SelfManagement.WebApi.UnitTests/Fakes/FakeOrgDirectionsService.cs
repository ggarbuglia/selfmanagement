namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeOrgDirectionsService : IOrgDirectionsService
    {
        private readonly List<OrgDirection> _items;

        public FakeOrgDirectionsService()
        {
            _items = new List<OrgDirection>
            {
                new OrgDirection()
                {
                    Id = 1,
                    Name = "Direction 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                },

                new OrgDirection()
                {
                    Id = 2,
                    Name = "Direction 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<OrgDirection>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<OrgDirection?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<OrgDirection> Post(OrgDirection entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, OrgDirection entity)
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeAdUserAccountProvisionsService : IAdUserAccountProvisionsService
    {
        private readonly List<AdUserAccountProvision> _items;

        public FakeAdUserAccountProvisionsService()
        {
            _items = new List<AdUserAccountProvision>
            {
                new AdUserAccountProvision()
                {
                    Id = 1,
                    Status = "Status 1",
                    HasError = false,
                    Error = string.Empty,
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    AdUserAccount = new AdUserAccount()
                },

                new AdUserAccountProvision()
                {
                    Id = 2,
                    Status = "Status 2",
                    HasError = false,
                    Error = string.Empty,
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    AdUserAccount = new AdUserAccount()
                }
            };
        }

        public async Task<IEnumerable<AdUserAccountProvision>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<AdUserAccountProvision?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<AdUserAccountProvision> Post(AdUserAccountProvision entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, AdUserAccountProvision entity)
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
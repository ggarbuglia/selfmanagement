using ProvinciaNET.SelfManagement.WebApi.Services;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Fakes
{
    internal class FakeAdUserAccountsService : ICrudServiceBase<AdUserAccount>
    {
        private readonly List<AdUserAccount> _items;

        public FakeAdUserAccountsService()
        {
            _items = new List<AdUserAccount>
            {
                new AdUserAccount()
                {
                    Id = 1,
                    SamAccountName = "SamAccountName 1",
                    UserPrincipalName = "UserPrincipalName 1",
                    EmailAddress = "EmailAddress 1",
                    GivenName = "GivenName 1",
                    SurName = "SurName 1",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Location = new OrgLocation(),
                    Membership = new OrgMembership()
                },

                new AdUserAccount()
                {
                    Id = 2,
                    SamAccountName = "SamAccountName 2",
                    UserPrincipalName = "UserPrincipalName 2",
                    EmailAddress = "EmailAddress 2",
                    GivenName = "GivenName 2",
                    SurName = "SurName 2",
                    Active = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Location = new OrgLocation(),
                    Membership = new OrgMembership()
                }
            };
        }

        public async Task<IEnumerable<AdUserAccount>> Get()
        {
            return await Task.FromResult(_items);
        }

        public async Task<AdUserAccount?> Get(int id)
        {
            var entity = _items.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<AdUserAccount> Post(AdUserAccount entity)
        {
            entity.Id = _items.Count + 1;
            _items.Add(entity);
            return await Task.FromResult(entity);
        }

        public Task Put(int id, AdUserAccount entity)
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
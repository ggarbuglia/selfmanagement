using ProvinciaNET.SelfManagement.WebApi.Controllers.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class AdUserAccountsControllerTests
    {
        private readonly ICrudServiceBase<AdUserAccount> _service;
        private readonly AdUserAccountsController _controller;

        public AdUserAccountsControllerTests()
        {
            var mock = new Mock<ILogger<AdUserAccountsController>>();
            ILogger<AdUserAccountsController> logger = mock.Object;

            _service = new FakeAdUserAccountsService();
            _controller = new AdUserAccountsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetAdUserAccounts();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<AdUserAccount>;
            var count = items?.Count();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.True(count >= 2);
        }

        [Fact]
        public async Task GetById_Returns200OkAsync()
        {
            // Arrange
            var id = 1;
            var name = "SamAccountName 1";

            // Act
            var result = await _controller.GetAdUserAccount(id);
            var item = (result.Result as ObjectResult)?.Value as AdUserAccount;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.SamAccountName);
        }

        [Fact]
        public async Task GetById_Returns404NotFoundAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetAdUserAccount(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "SamAccountName X";

            var entity = new AdUserAccount()
            {
                SamAccountName = name,
                UserPrincipalName = "UserPrincipalName 1",
                EmailAddress = "EmailAddress 1",
                GivenName = "GivenName 1",
                SurName = "SurName 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Location = new OrgLocation(),
                Membership = new OrgMembership()
            };

            // Act
            var result = await _controller.PostAdUserAccount(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as AdUserAccount;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<AdUserAccount>(item);
            Assert.Equal(name, item.SamAccountName);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new AdUserAccount()
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
            };

            // Act
            var result = await _controller.PostAdUserAccount(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "SamAccountName 2 Edited";
            var entity = new AdUserAccount()
            {
                Id = id,
                SamAccountName = name,
                UserPrincipalName = "UserPrincipalName 2",
                EmailAddress = "EmailAddress 2",
                GivenName = "GivenName 2",
                SurName = "SurName 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Location = new OrgLocation(),
                Membership = new OrgMembership()
            };

            // Act
            var result1 = await _controller.PutAdUserAccount(id, entity);
            var result2 = await _controller.GetAdUserAccount(id);
            var item = (result2.Result as ObjectResult)?.Value as AdUserAccount;

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<NoContentResult>(result1);

            Assert.NotNull(result2);
            Assert.IsType<OkObjectResult>(result2.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.SamAccountName);
        }

        [Fact]
        public async Task Put_Return400BadRequest()
        {
            // Arrange
            var id = 1;
            var entity = new AdUserAccount()
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
            };

            // Act
            var result = await _controller.PutAdUserAccount(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new AdUserAccount()
            {
                Id = id,
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
            };

            // Act
            var result = await _controller.PutAdUserAccount(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;

            // Act
            var result = await _controller.DeleteAdUserAccount(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;

            // Act
            var result = await _controller.DeleteAdUserAccount(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
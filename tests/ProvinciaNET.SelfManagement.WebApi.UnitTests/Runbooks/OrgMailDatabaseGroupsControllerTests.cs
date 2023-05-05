using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgMailDatabaseGroupsControllerTests
    {
        private readonly IOrgMailDatabaseGroupsService _service;
        private readonly OrgMailDatabaseGroupsController _controller;

        public OrgMailDatabaseGroupsControllerTests()
        {
            var mock = new Mock<ILogger<OrgMailDatabaseGroupsController>>();
            ILogger<OrgMailDatabaseGroupsController> logger = mock.Object;

            _service = new FakeOrgMailDatabaseGroupsService();
            _controller = new OrgMailDatabaseGroupsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgMailDatabaseGroups();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgMailDatabaseGroup>;
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
            var name = "MailDatabaseGroup 1";

            // Act
            var result = await _controller.GetOrgMailDatabaseGroup(id);
            var item = (result.Result as ObjectResult)?.Value as OrgMailDatabaseGroup;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.Name);
        }

        [Fact]
        public async Task GetById_Returns404NotFoundAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgMailDatabaseGroup(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "MailDatabaseGroup X";

            var entity = new OrgMailDatabaseGroup()
            {
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgMailDatabaseGroup(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgMailDatabaseGroup;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgMailDatabaseGroup>(item);
            Assert.Equal(name, item.Name);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgMailDatabaseGroup()
            {
                Id = 1,
                Name = "MailDatabaseGroup 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgMailDatabaseGroup(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "MailDatabaseGroup 2 Edited";
            var entity = new OrgMailDatabaseGroup()
            {
                Id = id,
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result1 = await _controller.PutOrgMailDatabaseGroup(id, entity);
            var result2 = await _controller.GetOrgMailDatabaseGroup(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgMailDatabaseGroup;

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<NoContentResult>(result1);

            Assert.NotNull(result2);
            Assert.IsType<OkObjectResult>(result2.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.Name);
        }

        [Fact]
        public async Task Put_Return400BadRequest()
        {
            // Arrange
            var id = 1;
            var entity = new OrgMailDatabaseGroup()
            {
                Id = 2,
                Name = "MailDatabaseGroup 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgMailDatabaseGroup(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgMailDatabaseGroup()
            {
                Id = id,
                Name = "MailDatabaseGroup 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgMailDatabaseGroup(id, entity);

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
            var result = await _controller.DeleteOrgMailDatabaseGroup(id);

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
            var result = await _controller.DeleteOrgMailDatabaseGroup(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
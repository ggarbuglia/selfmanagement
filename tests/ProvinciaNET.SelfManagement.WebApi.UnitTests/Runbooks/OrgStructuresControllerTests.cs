using ProvinciaNET.SelfManagement.WebApi.Controllers.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgStructuresControllerTests
    {
        private readonly ICrudServiceBase<OrgStructure> _service;
        private readonly OrgStructuresController _controller;

        public OrgStructuresControllerTests()
        {
            var mock = new Mock<ILogger<OrgStructuresController>>();
            ILogger<OrgStructuresController> logger = mock.Object;

            _service = new FakeOrgStructuresService();
            _controller = new OrgStructuresController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgStructures();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgStructure>;
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
            var group = "Group 1";

            // Act
            var result = await _controller.GetOrgStructure(id);
            var item = (result.Result as ObjectResult)?.Value as OrgStructure;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(group, item?.Group);
        }

        [Fact]
        public async Task GetById_Returns404NotFoundAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgStructure(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var group = "Group X";

            var entity = new OrgStructure()
            {
                Group = group,
                OrgUnit = "OrgUnit 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Section = new OrgSection(),
                MailDatabaseGroup = new OrgMailDatabaseGroup()
            };

            // Act
            var result = await _controller.PostOrgStructure(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgStructure;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgStructure>(item);
            Assert.Equal(group, item.Group);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgStructure()
            {
                Id = 1,
                Group = "Group 1",
                OrgUnit = "OrgUnit 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Section = new OrgSection(),
                MailDatabaseGroup = new OrgMailDatabaseGroup()
            };

            // Act
            var result = await _controller.PostOrgStructure(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var group = "Group 2 Edited";
            var entity = new OrgStructure()
            {
                Id = id,
                Group = group,
                OrgUnit = "OrgUnit 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Section = new OrgSection(),
                MailDatabaseGroup = new OrgMailDatabaseGroup()
            };

            // Act
            var result1 = await _controller.PutOrgStructure(id, entity);
            var result2 = await _controller.GetOrgStructure(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgStructure;

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<NoContentResult>(result1);

            Assert.NotNull(result2);
            Assert.IsType<OkObjectResult>(result2.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(group, item?.Group);
        }

        [Fact]
        public async Task Put_Return400BadRequest()
        {
            // Arrange
            var id = 1;
            var entity = new OrgStructure()
            {
                Id = 2,
                Group = "Group 2",
                OrgUnit = "OrgUnit 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Section = new OrgSection(),
                MailDatabaseGroup = new OrgMailDatabaseGroup()
            };

            // Act
            var result = await _controller.PutOrgStructure(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgStructure()
            {
                Id = id,
                Group = "Group 1",
                OrgUnit = "OrgUnit 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Section = new OrgSection(),
                MailDatabaseGroup = new OrgMailDatabaseGroup()
            };

            // Act
            var result = await _controller.PutOrgStructure(id, entity);

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
            var result = await _controller.DeleteOrgStructure(id);

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
            var result = await _controller.DeleteOrgStructure(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
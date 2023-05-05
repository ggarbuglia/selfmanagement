using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgMembershipsControllerTests
    {
        private readonly IOrgMembershipsService _service;
        private readonly OrgMembershipsController _controller;

        public OrgMembershipsControllerTests()
        {
            var mock = new Mock<ILogger<OrgMembershipsController>>();
            ILogger<OrgMembershipsController> logger = mock.Object;

            _service = new FakeOrgMembershipsService();
            _controller = new OrgMembershipsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgMemberships();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgMembership>;
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
            var name = "AdGroupDisplayName 1";

            // Act
            var result = await _controller.GetOrgMembership(id);
            var item = (result.Result as ObjectResult)?.Value as OrgMembership;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.AdGroupDisplayName);
        }

        [Fact]
        public async Task GetById_Returns404NotFoundAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgMembership(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "AdGroupDisplayName X";

            var entity = new OrgMembership()
            {
                AdGroupDisplayName = name,
                AdGroupAccountName = "AdGroupAccountName 1",
                Show = true,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Structure = new OrgStructure()
            };

            // Act
            var result = await _controller.PostOrgMembership(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgMembership;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgMembership>(item);
            Assert.Equal(name, item.AdGroupDisplayName);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgMembership()
            {
                Id = 1,
                AdGroupDisplayName = "AdGroupDisplayName 1",
                AdGroupAccountName = "AdGroupAccountName 1",
                Show = true,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Structure = new OrgStructure()
            };

            // Act
            var result = await _controller.PostOrgMembership(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "AdGroupDisplayName 2 Edited";
            var entity = new OrgMembership()
            {
                Id = id,
                AdGroupDisplayName = name,
                AdGroupAccountName = "AdGroupAccountName 2",
                Show = true,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Structure = new OrgStructure()
            };

            // Act
            var result1 = await _controller.PutOrgMembership(id, entity);
            var result2 = await _controller.GetOrgMembership(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgMembership;

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<NoContentResult>(result1);

            Assert.NotNull(result2);
            Assert.IsType<OkObjectResult>(result2.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.AdGroupDisplayName);
        }

        [Fact]
        public async Task Put_Return400BadRequest()
        {
            // Arrange
            var id = 1;
            var entity = new OrgMembership()
            {
                Id = 2,
                AdGroupDisplayName = "AdGroupDisplayName 2",
                AdGroupAccountName = "AdGroupAccountName 2",
                Show = true,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Structure = new OrgStructure()
            };

            // Act
            var result = await _controller.PutOrgMembership(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgMembership()
            {
                Id = id,
                AdGroupDisplayName = "AdGroupDisplayName 1",
                AdGroupAccountName = "AdGroupAccountName 1",
                Show = true,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                Structure = new OrgStructure()
            };

            // Act
            var result = await _controller.PutOrgMembership(id, entity);

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
            var result = await _controller.DeleteOrgMembership(id);

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
            var result = await _controller.DeleteOrgMembership(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgDirectionsControllerTests
    {
        private readonly IOrgDirectionsService _service;
        private readonly OrgDirectionsController _controller;

        public OrgDirectionsControllerTests()
        {
            var mock = new Mock<ILogger<OrgDirectionsController>>();
            ILogger<OrgDirectionsController> logger = mock.Object;

            _service = new FakeOrgDirectionsService();
            _controller = new OrgDirectionsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgDirections();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgDirection>;
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
            var name = "Direction 1";

            // Act
            var result = await _controller.GetOrgDirection(id);
            var item = (result.Result as ObjectResult)?.Value as OrgDirection;

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
            var result = await _controller.GetOrgDirection(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "Direction X";

            var entity = new OrgDirection()
            {
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgDirection(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgDirection;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgDirection>(item);
            Assert.Equal(name, item.Name);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgDirection()
            {
                Id = 1,
                Name = "Direction 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgDirection(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "Direction 2 Edited";
            var entity = new OrgDirection()
            {
                Id = id,
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result1 = await _controller.PutOrgDirection(id, entity);
            var result2 = await _controller.GetOrgDirection(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgDirection;

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
            var entity = new OrgDirection()
            {
                Id = 2,
                Name = "Direction 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgDirection(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgDirection()
            {
                Id = id,
                Name = "Direction 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgDirection(id, entity);

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
            var result = await _controller.DeleteOrgDirection(id);

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
            var result = await _controller.DeleteOrgDirection(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
using ProvinciaNET.SelfManagement.WebApi.Controllers.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class AdUserAccountProvisionsControllerTests
    {
        private readonly ICrudServiceBase<AdUserAccountProvision> _service;
        private readonly AdUserAccountProvisionsController _controller;

        public AdUserAccountProvisionsControllerTests()
        {
            var mock = new Mock<ILogger<AdUserAccountProvisionsController>>();
            ILogger<AdUserAccountProvisionsController> logger = mock.Object;

            _service = new FakeAdUserAccountProvisionsService();
            _controller = new AdUserAccountProvisionsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetAdUserAccountProvisions();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<AdUserAccountProvision>;
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
            var name = "Status 1";

            // Act
            var result = await _controller.GetAdUserAccountProvision(id);
            var item = (result.Result as ObjectResult)?.Value as AdUserAccountProvision;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.Status);
        }

        [Fact]
        public async Task GetById_Returns404NotFoundAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetAdUserAccountProvision(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "Status X";

            var entity = new AdUserAccountProvision()
            {
                Status = name,
                HasError = false,
                Error = string.Empty,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                AdUserAccount = new AdUserAccount()
            };

            // Act
            var result = await _controller.PostAdUserAccountProvision(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as AdUserAccountProvision;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<AdUserAccountProvision>(item);
            Assert.Equal(name, item.Status);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new AdUserAccountProvision()
            {
                Id = 1,
                Status = "Status 1",
                HasError = false,
                Error = string.Empty,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                AdUserAccount = new AdUserAccount()
            };

            // Act
            var result = await _controller.PostAdUserAccountProvision(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "Status 2 Edited";
            var entity = new AdUserAccountProvision()
            {
                Id = id,
                Status = name,
                HasError = false,
                Error = string.Empty,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                AdUserAccount = new AdUserAccount()
            };

            // Act
            var result1 = await _controller.PutAdUserAccountProvision(id, entity);
            var result2 = await _controller.GetAdUserAccountProvision(id);
            var item = (result2.Result as ObjectResult)?.Value as AdUserAccountProvision;

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<NoContentResult>(result1);

            Assert.NotNull(result2);
            Assert.IsType<OkObjectResult>(result2.Result);
            Assert.Equal(id, item?.Id);
            Assert.Equal(name, item?.Status);
        }

        [Fact]
        public async Task Put_Return400BadRequest()
        {
            // Arrange
            var id = 1;
            var entity = new AdUserAccountProvision()
            {
                Id = 2,
                Status = "Status 2",
                HasError = false,
                Error = string.Empty,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                AdUserAccount = new AdUserAccount()
            };

            // Act
            var result = await _controller.PutAdUserAccountProvision(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new AdUserAccountProvision()
            {
                Id = id,
                Status = "Status 1",
                HasError = false,
                Error = string.Empty,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                AdUserAccount = new AdUserAccount()
            };

            // Act
            var result = await _controller.PutAdUserAccountProvision(id, entity);

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
            var result = await _controller.DeleteAdUserAccountProvision(id);

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
            var result = await _controller.DeleteAdUserAccountProvision(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
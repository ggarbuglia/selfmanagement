using ProvinciaNET.SelfManagement.WebApi.Controllers.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgLocationsControllerTests
    {
        private readonly ICrudServiceBase<OrgLocation> _service;
        private readonly OrgLocationsController _controller;

        public OrgLocationsControllerTests()
        {
            var mock = new Mock<ILogger<OrgLocationsController>>();
            ILogger<OrgLocationsController> logger = mock.Object;

            _service = new FakeOrgLocationsService();
            _controller = new OrgLocationsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgLocations();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgLocation>;
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
            var name = "Location 1";

            // Act
            var result = await _controller.GetOrgLocation(id);
            var item = (result.Result as ObjectResult)?.Value as OrgLocation;

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
            var result = await _controller.GetOrgLocation(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "Location X";

            var entity = new OrgLocation()
            {
                Name = name,
                Address = "Address 1",
                PostalCode = "PostalCode 1",
                City = "City 1",
                AdGroupDisplayName = "AdGroupDisplayName 1",
                AdGroupAccountName = "AdGroupAccountName 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgLocation(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgLocation;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgLocation>(item);
            Assert.Equal(name, item.Name);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgLocation()
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
            };

            // Act
            var result = await _controller.PostOrgLocation(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "Location 2 Edited";
            var entity = new OrgLocation()
            {
                Id = id,
                Name = name,
                Address = "Address 2",
                PostalCode = "PostalCode 2",
                City = "City 2",
                AdGroupDisplayName = "AdGroupDisplayName 2",
                AdGroupAccountName = "AdGroupAccountName 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result1 = await _controller.PutOrgLocation(id, entity);
            var result2 = await _controller.GetOrgLocation(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgLocation;

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
            var entity = new OrgLocation()
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
            };

            // Act
            var result = await _controller.PutOrgLocation(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgLocation()
            {
                Id = id,
                Name = "Location 1",
                Address = "Address 1",
                PostalCode = "PostalCode 1",
                City = "City 1",
                AdGroupDisplayName = "AdGroupDisplayName 1",
                AdGroupAccountName = "AdGroupAccountName 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgLocation(id, entity);

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
            var result = await _controller.DeleteOrgLocation(id);

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
            var result = await _controller.DeleteOrgLocation(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
namespace ProvinciaNET.SelfManagement.WebApi.UnitTests
{
    public class OrgCostCentersControllerTests
    {
        private readonly IOrgCostCentersService _service;
        private readonly OrgCostCentersController _controller;

        public OrgCostCentersControllerTests()
        {
            var mock = new Mock<ILogger<OrgCostCentersController>>();
            ILogger<OrgCostCentersController> logger = mock.Object;

            _service = new FakeOrgCostCentersService();
            _controller = new OrgCostCentersController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgCostCenters();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<Core.Entities.OrgCostCenter>;
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
            var name = "Cost Center 1";

            // Act
            var result = await _controller.GetOrgCostCenter(id);
            var item = (result.Result as ObjectResult)?.Value as Core.Entities.OrgCostCenter;

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
            var result = await _controller.GetOrgCostCenter(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "Cost Center X";

            var entity = new Core.Entities.OrgCostCenter()
            {
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgCostCenter(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as Core.Entities.OrgCostCenter;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<Core.Entities.OrgCostCenter>(item);
            Assert.Equal(name, item.Name);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new Core.Entities.OrgCostCenter()
            {
                Id = 1,
                Name = "Cost Center 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PostOrgCostCenter(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "Cost Center 2 Edited";
            var entity = new Core.Entities.OrgCostCenter()
            {
                Id        = id,
                Name      = name,
                Active    = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result1 = await _controller.PutOrgCostCenter(id, entity);
            var result2 = await _controller.GetOrgCostCenter(id);
            var item = (result2.Result as ObjectResult)?.Value as Core.Entities.OrgCostCenter;

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
            var entity = new Core.Entities.OrgCostCenter()
            {
                Id        = 2,
                Name      = "Cost Center 2",
                Active    = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgCostCenter(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id     = 500;
            var name   = "Cost Center 2 Edited";
            var entity = new Core.Entities.OrgCostCenter()
            {
                Id        = id,
                Name      = name,
                Active    = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now
            };

            // Act
            var result = await _controller.PutOrgCostCenter(id, entity);

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
            var result = await _controller.DeleteOrgCostCenter(id);

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
            var result = await _controller.DeleteOrgCostCenter(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
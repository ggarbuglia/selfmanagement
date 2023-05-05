using ProvinciaNET.SelfManagement.Core.Entities;

namespace ProvinciaNET.SelfManagement.WebApi.UnitTests.Runbooks
{
    public class OrgSectionsControllerTests
    {
        private readonly IOrgSectionsService _service;
        private readonly OrgSectionsController _controller;

        public OrgSectionsControllerTests()
        {
            var mock = new Mock<ILogger<OrgSectionsController>>();
            ILogger<OrgSectionsController> logger = mock.Object;

            _service = new FakeOrgSectionsService();
            _controller = new OrgSectionsController(logger, _service);
        }

        [Fact]
        public async Task Get_Returns200OkAsync()
        {
            // Arrange

            // Act
            var result = await _controller.GetOrgSections();
            var items = (result.Result as ObjectResult)?.Value as IEnumerable<OrgSection>;
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
            var name = "Section 1";

            // Act
            var result = await _controller.GetOrgSection(id);
            var item = (result.Result as ObjectResult)?.Value as OrgSection;

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
            var result = await _controller.GetOrgSection(500);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Post_Return201CreatedAtActionAsync()
        {
            // Arrange
            var name = "Section X";

            var entity = new OrgSection()
            {
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                CostCenter = new OrgCostCenter(),
                Direction = new OrgDirection()
            };

            // Act
            var result = await _controller.PostOrgSection(entity);
            var item = (result.Result as CreatedAtActionResult)?.Value as OrgSection;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<OrgSection>(item);
            Assert.Equal(name, item.Name);
        }

        [Fact]
        public async Task Post_Return400BadRequestAsync()
        {
            // Arrange
            var entity = new OrgSection()
            {
                Id = 1,
                Name = "Section 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                CostCenter = new OrgCostCenter(),
                Direction = new OrgDirection()
            };

            // Act
            var result = await _controller.PostOrgSection(entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Put_Return204NoContentAsync()
        {
            // Arrange
            var id = 2;
            var name = "Section 2 Edited";
            var entity = new OrgSection()
            {
                Id = id,
                Name = name,
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                CostCenter = new OrgCostCenter(),
                Direction = new OrgDirection()
            };

            // Act
            var result1 = await _controller.PutOrgSection(id, entity);
            var result2 = await _controller.GetOrgSection(id);
            var item = (result2.Result as ObjectResult)?.Value as OrgSection;

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
            var entity = new OrgSection()
            {
                Id = 2,
                Name = "Section 2",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                CostCenter = new OrgCostCenter(),
                Direction = new OrgDirection()
            };

            // Act
            var result = await _controller.PutOrgSection(id, entity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Return404NotFoundAsync()
        {
            // Arrange
            var id = 500;
            var entity = new OrgSection()
            {
                Id = id,
                Name = "Section 1",
                Active = true,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                CostCenter = new OrgCostCenter(),
                Direction = new OrgDirection()
            };

            // Act
            var result = await _controller.PutOrgSection(id, entity);

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
            var result = await _controller.DeleteOrgSection(id);

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
            var result = await _controller.DeleteOrgSection(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
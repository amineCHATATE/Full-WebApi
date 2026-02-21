using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using BlazorWasm.Pages.Products;
using BlazorWasm.Services;

namespace BlazorWasm.Test.ComponentTest
{
    public class ProductListCompoentTest: BunitContext
    {
        [Fact]
        public void ProductListComponent_DispalyData_Correctly()
        {
            // Arrange
            var products = Fixture.GetMockProducts();
            var mockProductService =new Mock<IProductService>();

            Services.AddSingleton(mockProductService.Object);
            mockProductService.Setup(service => service.GetAllProducts()).Returns(Task.FromResult(products));

            // Act
            var component = Render<ProductListComponent>();
            var table = component.FindAll("table");
            var headers = component.FindAll("thead tr th");
            var rows = component.FindAll("tbody tr");

            var firstRowCell = rows[0].QuerySelectorAll("td");
            var secondRowCell = rows[1].Children;

            // Assert
            Assert.NotNull(table);
            Assert.Equal(4, headers.Count);
            Assert.Equal("Id", headers[0].TextContent);
            Assert.Equal("Name", headers[1].TextContent);
            Assert.Equal("Quantity", headers[2].TextContent);
            Assert.Equal("Actions", headers[3].TextContent);

            Assert.Equal(2, rows.Count);

            Assert.Equal("1", firstRowCell[0].TextContent);
            Assert.Equal("Product 1", firstRowCell[1].TextContent);
            Assert.Equal("10", firstRowCell[2].TextContent);

            Assert.Equal("2", secondRowCell[0].TextContent);
            Assert.Equal("Product 2", secondRowCell[1].TextContent);
            Assert.Equal("20", secondRowCell[2].TextContent);

        }
    }
}

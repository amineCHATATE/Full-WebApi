using BlazorWasm.Services;
using Bunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using BlazorWasm.Models;

namespace BlazorWasm.Test.ComponentTest
{
    public class AddProductComponenetTest: BunitContext
    {
        [Fact]
        public void AddProductComponent_Render_Correctly()
        {
            // Arrange
            var mockProduct = Fixture.GetMockProduct();
            var mockProductService = new Mock<IProductService>();
            Services.AddSingleton<IProductService>(mockProductService.Object);
            mockProductService.Setup(service => service.CreateProduct(It.IsAny<Product>())).ReturnsAsync(1);

            // Act
            var component = Render<AddProductComponent>();
            var form = component.Find("form");
            var nameInput = component.Find("#name");
            var quantityInput = component.Find("#quantity");
            var submitButton = component.Find("button[type='submit']");
            // Assert
            Assert.NotNull(form);
            Assert.NotNull(nameInput);
            Assert.NotNull(quantityInput);
            Assert.NotNull(submitButton);
        }
    }
}

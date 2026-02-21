using BlazorWasm.Models;

namespace BlazorWasm.Test.ComponentTest
{
    public static class Fixture
    {
        public static List<Product> GetMockProducts()
        {
            return new List<Product>
            {
                new() { Id = 1, Name = "Product 1", Quantity = 10 },
                new() { Id = 2, Name = "Product 2", Quantity = 20 }
            };
        }

        public static Product GetMockProduct()
        {
            return new() { Id = 1, Name = "Product 1", Quantity = 10 };
        }
    }
}

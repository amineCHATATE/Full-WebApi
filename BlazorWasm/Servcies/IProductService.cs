using BlazorWasm.Models;

namespace BlazorWasm.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product?> GetProductById(int id);
        public Task<int> DeleteProduct(int id);
        public Task<int> UpdateProduct(Product product);
        public Task<int> CreateProduct(Product product);

    }
}

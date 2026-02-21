using BlazorWasm.Models;
using BlazorWasm.Services;
using System.Net.Http.Json;

namespace BlazorWasm.Servcies
{
    public class ProductService(HttpClient _httpClient) : IProductService
    {
        public async Task<int> CreateProduct(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            return response.IsSuccessStatusCode ? int.Parse(await response.Content.ReadAsStringAsync()) : -1;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products{id}");
            return response.IsSuccessStatusCode ? int.Parse(await response.Content.ReadAsStringAsync()) : -1;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
                return products!;
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task<Product?> GetProductById(int id)
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<Product>("api/products");
                return product!;
            }
            catch (Exception ex)
            {
                return new Product();
            }
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync("api/products", product);
            return response.IsSuccessStatusCode ? int.Parse(await response.Content.ReadAsStringAsync()) : -1;
        }
    }
}

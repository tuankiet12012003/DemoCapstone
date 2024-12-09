using Product.API.Dto;
using ProductService.Models;

namespace Product.API.Services.Interface
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task AddProduct(Products product);
        Task UpdateProduct(Products product);
        Task DeleteProduct(int id);
    }
}

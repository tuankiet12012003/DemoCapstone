using Microsoft.EntityFrameworkCore;
using Product.API.Services.Interface;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductServiceHandler : IProductService
    {
        private readonly ProductDbContext _context;

        public ProductServiceHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Products product)
        {
            try
            {
                var existingProduct = await GetProductById(product.Id);
                if (existingProduct != null)
                {
                    throw new Exception("Product already exists");
                }
                else
                {
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProduct(Products product)
        {
            try
            {
                var existingProduct = await GetProductById(product.Id);
                if (existingProduct == null)
                {
                    throw new Exception("Product does not exist");
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (existingProduct == null)
                {
                    throw new Exception("Product not found");
                }
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

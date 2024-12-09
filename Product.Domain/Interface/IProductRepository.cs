using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Interface
{
    public interface IProductRepository
    {
        Task<int> CreateProductAsync(ProductEntity product);
        Task<List<ProductEntity>> GetProductsAsync(CancellationToken cancellationToken);
    }
}

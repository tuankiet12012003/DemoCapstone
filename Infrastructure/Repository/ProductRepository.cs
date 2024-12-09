using AutoMapper;
using Product.Domain.Entities;
using Product.Domain.Interface;
using Product.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class ProductRepository : RepositoryBase<ProductEntity, ProductEntity, ProductDbContext>, IProductRepository
    {
        public ProductRepository(ProductDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}

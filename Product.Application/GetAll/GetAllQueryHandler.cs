using MediatR;
using Product.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public GetAllQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var product = await this._repository.GetProductsAsync(cancellationToken);
            if (product == null) throw new InvalidOperationException("Không tìm thấy bất kỳ Product nào.");

            var productDto = product.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToList();

            return productDto;

        }
    }
}

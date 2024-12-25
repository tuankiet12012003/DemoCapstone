using AutoMapper;
using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application
{
    public static class ProductDTOMappingExtensions
    {
        public static ProductDTO MapToProductDTO(this ProductEntity entity, IMapper mapper)
          => mapper.Map<ProductDTO>(entity);
        public static List<ProductDTO> MapToThongTinCongTyDtoList(this IEnumerable<ProductEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToProductDTO(mapper)).ToList();
    }
}

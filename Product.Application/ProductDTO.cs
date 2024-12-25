using AutoMapper;
using Product.Application.Commons;
using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Product.Application
{
    public class ProductDTO : IMapFrom<ProductEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductEntity, ProductDTO>();
        }
    }
}

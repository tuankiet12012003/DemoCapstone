using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
    }
}

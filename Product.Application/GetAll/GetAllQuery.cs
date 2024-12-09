using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Product.Application.GetAll
{
    public class GetAllQuery : IRequest<List<ProductDTO>>
    {
    }
}

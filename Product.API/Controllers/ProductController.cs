using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.GetAll;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllorders()
        {
            var orders = await _orderService.GetAllorders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetorderById(int id)
        {
            var order = await _orderService.GetorderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Addorder([FromBody] orderDTO orderDTO)
        {
            var order = new orders
            {
                Name = orderDTO.Name,
                Price = orderDTO.Price
            };

            await _orderService.Addorder(order);

            return CreatedAtAction(nameof(GetorderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateorder(int id, [FromBody] orderDTO orderDTO)
        {
            var existingorder = await _orderService.GetorderById(id);
            if (existingorder == null)
            {
                return NotFound();
            }

            existingorder.Name = orderDTO.Name;
            existingorder.Price = orderDTO.Price;

            await _orderService.Updateorder(existingorder);

            return Ok(existingorder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder(int id)
        {
            var existingorder = await _orderService.GetorderById(id);
            if (existingorder == null)
            {
                return NotFound();
            }

            await _orderService.Deleteorder(id);
            return Ok(existingorder);
        }
    }*/
}

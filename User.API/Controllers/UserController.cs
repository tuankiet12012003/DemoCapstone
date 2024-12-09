using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.GetAll;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

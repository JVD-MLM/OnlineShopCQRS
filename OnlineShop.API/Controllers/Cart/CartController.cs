using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.ShoppingCart;
using OnlineShop.Application.Features.Cart.Requests.Command;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            var request = new AddToCartRequest()
            {
                AddToCartDto = addToCartDto
            };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // POST api/<CartController>
        [HttpPut]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromCartDto removeFromCartDto)
        {
            var request = new RemoveFromCartRequest()
            {
                RemoveFromCartDto = removeFromCartDto
            };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.Product;
using OnlineShop.Application.Features.Product.Requests.Command;
using OnlineShop.Application.Features.Product.Requests.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers.Product
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

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllProductRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductRequest() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDto createProductDto)
        {
            var request = new CreateProductRequest() { CreateProductDto = createProductDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var request = new UpdateProductRequest() { UpdateProductDto = updateProductDto };
            request.UpdateProductDto.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteProductRequest() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

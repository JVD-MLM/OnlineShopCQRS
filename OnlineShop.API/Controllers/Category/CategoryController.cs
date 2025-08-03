using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.Category;
using OnlineShop.Application.Features.Category.Requests.Command;
using OnlineShop.Application.Features.Category.Requests.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllCategoryRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetCategoryRequest() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryDto createCategoryDto)
        {
            var request = new CreateCategoryRequest() { CreateCategoryDto = createCategoryDto };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {

            var request = new UpdateCategoryRequest() { UpdateCategoryDto = updateCategoryDto };
            request.UpdateCategoryDto.Id = id;
            var result = await _mediator.Send(request);  // todo: fix bug
            return Ok(result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteCategoryRequest() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

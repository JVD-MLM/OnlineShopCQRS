using MediatR;
using OnlineShop.Application.DTOs.Category;

namespace OnlineShop.Application.Features.Category.Requests.Command
{
    public class CreateCategoryRequest : IRequest<Unit>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}

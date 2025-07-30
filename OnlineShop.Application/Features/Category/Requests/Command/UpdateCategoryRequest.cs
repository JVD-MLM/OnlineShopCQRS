using MediatR;
using OnlineShop.Application.DTOs.Category;

namespace OnlineShop.Application.Features.Category.Requests.Command
{
    public class UpdateCategoryRequest : IRequest<Unit>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}

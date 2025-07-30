using MediatR;
using OnlineShop.Application.DTOs.Category;

namespace OnlineShop.Application.Features.Category.Requests.Query
{
    public class GetAllCategoryRequest: IRequest<List<CategoryDto>>
    {
    }
}

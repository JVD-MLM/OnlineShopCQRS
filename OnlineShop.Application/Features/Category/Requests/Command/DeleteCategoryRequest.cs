using MediatR;

namespace OnlineShop.Application.Features.Category.Requests.Command
{
    public class DeleteCategoryRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

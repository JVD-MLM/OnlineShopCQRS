using MediatR;
using OnlineShop.Application.DTOs.User;

namespace OnlineShop.Application.Features.User.Requests.Command
{
    public class RegisterUserRequest : IRequest<bool>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}

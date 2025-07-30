using MediatR;
using OnlineShop.Application.DTOs.User;

namespace OnlineShop.Application.Features.User.Requests.Query
{
    public class LoginUserRequest : IRequest<string>
    {
        public LoginUserDto LoginUserDto { get; set; }
    }
}

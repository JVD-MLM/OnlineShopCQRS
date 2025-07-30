using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.User.Requests.Query;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace OnlineShop.Application.Features.User.Handlers.Query
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithUserName(request.LoginUserDto.UserName);

            if (user == null)
            {
                return "User not found";
            }

            if (request.LoginUserDto.Password != user.Password)
            {
                return "User not found";
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:Key"]));
            var card = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: card
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

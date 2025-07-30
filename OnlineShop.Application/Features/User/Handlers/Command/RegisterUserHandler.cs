using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.User.Requests.Command;

namespace OnlineShop.Application.Features.User.Handlers.Command
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.Users.User>(request.CreateUserDto);
            // todo: user.Password => HashCode password service
            await _userRepository.Create(user);
            return true;
        }
    }
}

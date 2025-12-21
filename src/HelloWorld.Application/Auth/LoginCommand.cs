using HelloWorld.Application.Interfaces;
using HelloWorld.Application.Services;
using HelloWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Auth
{
    public record LoginCommand() : IRequest<string>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler(IRepository<User> _userRepository,IJwtProvider _jwtProvider) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByFilterAsync(x => x.UserName == request.UsernameOrEmail || x.Email == request.UsernameOrEmail);
            if (user is null) return "Kullanıcı bilgileri veya şifre geçersiz.";

            var isPasswordValid = user.VerifyPassword(request.Password);
            if (!isPasswordValid) return "Kullanıcı bilgileri veya şifre geçersiz.";

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}

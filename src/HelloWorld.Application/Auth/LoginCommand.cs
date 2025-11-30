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
    public record LoginCommand(string username , string password) : IRequest<string>;
    public class LoginCommandHandler(IRepository<User> _userRepository,IJwtProvider _jwtProvider) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByFilterASync(x => x.UserName == request.username);
            if (user is null) return "Kullanıcı adı veya şifre geçersiz.";

            var isPasswordValid = user.VerifyPassword(request.password);
            if (!isPasswordValid) return "Kullanıcı adı veya şifre geçersiz.";

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}

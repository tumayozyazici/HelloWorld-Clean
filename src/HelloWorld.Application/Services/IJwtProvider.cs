using HelloWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Services
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}

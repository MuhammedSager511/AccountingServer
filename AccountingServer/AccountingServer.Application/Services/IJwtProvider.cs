using AccountingServer.Application.Features.Auth.Login;
using AccountingServer.Domain.Entities;

namespace AccountingServer.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}

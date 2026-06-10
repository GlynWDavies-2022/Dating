using Dating.Domain.Entities;

namespace Dating.Application.Interfaces;

public interface ITokenService
{
    public string CreateToken(User user);
}

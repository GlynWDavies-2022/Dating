using Dating.Application.DTO;
using Dating.Application.Interfaces;
using Dating.Application.Services;
using Dating.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Dating.Application.Extensions;

public static class UserExtensions
{
    public static UserDTO ToUserDTO(this User source, ITokenService tokenService)
    {
        var userDTO = new UserDTO
        {
            Id = source.Id.ToString(),
            Email = source.Email,
            DisplayName = source.DisplayName,
            ImageURL = string.Empty,
            Token = tokenService.CreateToken(source)
        };

        return userDTO;
    }
}

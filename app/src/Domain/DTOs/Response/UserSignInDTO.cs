using Planets.Domain.Entities;

namespace Planets.Domain.DTO.Response
{
    public class UserSignInDTO
    {
        public required string Username { get; set; }

        public string? Name { get; set; }

        public required string Email { get; set; }

        public bool? ReceiveMessages { get; set; }

        public static implicit operator UserSignInDTO(UserEntity entitiy) => new UserSignInDTO()
        {
            Name = entitiy.Name,
            Email = entitiy.Email,
            Username = entitiy.Username,
            ReceiveMessages = entitiy.ReceiveMessages,
        };
    }
}
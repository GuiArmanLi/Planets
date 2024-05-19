using Planets.Domain.DTO.Request;

namespace Planets.Domain.Entities
{
    // [Table("Users")]
    public class UserEntity : BaseEntity
    {
        // [Key]
        // [Column(TypeName = "varchar(20)")]
        public required string Username { get; set; }

        // [Column(TypeName = "varchar(14)")]
        public string? Name { get; set; }

        // [Column(TypeName = "varchar(100)")]
        // [DataType(DataType.Password)]
        public required string Password { get; set; }

        // [Column(TypeName = "varchar(50)")]
        public required string Email { get; set; }

        // [Column(TypeName = "bit")]
        public bool? ReceiveMessages { get; set; }

        public static implicit operator UserEntity(UserSignUpDTO dto) => new UserEntity()
        {
            Name = dto.Name,
            Email = dto.Email,
            Username = dto.Username,
            Password = dto.Password,
            ReceiveMessages = dto.ReceiveMessages
        };

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planets.Application.DTO
{
    public class UserSignUpDTO
    {
        [Required(ErrorMessage = "The Email field is mandatory")]
        [StringLength(20, MinimumLength = 4)]
        public required string Username { get; set; }

        [StringLength(14, MinimumLength = 3, ErrorMessage = "The Name field must be between 3 and 14 characters")]
        public string? Name { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "The Password field must be between 8 and 16 characters long")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The Email field must be between 10 and 50 characters")]
        [RegularExpression(@"^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b$", ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Column(TypeName = "bit")]
        public bool? ReceiveMessages { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planets.Infra.Data.Entities
{
    [Table("Users")]
    public class UserEntitiy
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public required string Username { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string Email { get; set; }

        [Column(TypeName = "bit")]
        public bool? ReceiveMessages { get; set; }
    }
}
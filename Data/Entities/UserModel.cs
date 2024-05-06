using System.ComponentModel.DataAnnotations;

namespace Planets.Data.Entities
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsMessageAvaliable { get; set; }
    }
}
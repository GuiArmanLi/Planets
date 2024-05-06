namespace Planets.Models
{
    public class UserModelView
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsMessageAvaliable { get; set; }


        public override string ToString()
        {
            return $"Name: {Name} Username: {Username} Password: {Password} Email: {Email}";
        }
    }
}
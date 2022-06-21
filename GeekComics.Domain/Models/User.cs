namespace GeekComics.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

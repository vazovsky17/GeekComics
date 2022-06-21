namespace GeekComics.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public double Bonuses { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}

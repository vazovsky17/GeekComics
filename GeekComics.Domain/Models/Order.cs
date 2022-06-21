namespace GeekComics.Domain.Models
{
    public class Order : DomainObject
    {
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDelivered { get; set; }
    }
}

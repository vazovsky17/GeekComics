namespace GeekComics.Domain.Models
{
    /// <summary> Товар, находящийся у пользователя в корзине </summary>
    public class ProductInBusket : DomainObject
    {
        /// <summary> Товар </summary>
        public Product Product { get; set; }

        /// <summary> Количество </summary>
        public int Count { get; set; }
    }
}

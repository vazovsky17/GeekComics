namespace GeekComics.Domain.Models
{
    /// <summary> Данные о заказе </summary>
    public class Order : DomainObject
    {
        /// <summary> Список товаров </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary> Общая стоимость </summary>
        public double Price { get; set; }

        /// <summary> Количество списанных бонусов </summary>
        public double SpentBonusesCount { get; set; }

        /// <summary> Количесво начисленных бонусов </summary>
        public double AccruedBonusesCount { get; set; }

        /// <summary> Дата создания заказа </summary>
        public DateTime DateCreated { get; set; }

        /// <summary> Дата доставки </summary>
        public DateTime DateDelivered { get; set; }
    }
}

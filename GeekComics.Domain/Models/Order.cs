namespace GeekComics.Domain.Models
{
    /// <summary> Данные о заказе </summary>
    public class Order : DomainObject
    {
        /// <summary> Список товаров </summary>
        public IEnumerable<ProductInBusket> Products { get; set; }

        /// <summary> Общая стоимость </summary>
        public double Price { get; set; }

        /// <summary> Действия с бонусами, связанные с данным заказом </summary>
        public BonusAction BonusAction { get; set; }

        /// <summary> Дата создания заказа </summary>
        public DateTime DateCreated { get; set; }

        /// <summary> Дата доставки </summary>
        public DateTime DateDelivered { get; set; }

        /// <summary> Отменен ли заказ </summary>
        public bool IsCancelled { get; set; }
    }
}

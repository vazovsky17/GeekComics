namespace GeekComics.Domain.Models
{
    /// <summary> Информация о товаре </summary>
    public class Product : DomainObject
    {
        /// <summary> Наименование товара </summary>
        public string Name { get; set; }

        /// <summary> Описание товара </summary>
        public string Description { get; set; }

        /// <summary> Стоимость </summary>
        public string Price { get; set; }

        /// <summary> Количество в наличии в магазине </summary>
        public int StoreAvailabilityCount { get; set; }

        /// <summary> Количество в наличии на складе </summary>
        public int StockAvailabilityCount { get; set; }
    }
}

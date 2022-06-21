using System.ComponentModel.DataAnnotations.Schema;

namespace GeekComics.Domain.Models
{
    /// <summary> Данные об аккаунте </summary>
    public class Account : DomainObject
    {
        /// <summary> Владелец аккаунта (чтобы не хранить все заказы и прочее в купе с регистрационными данными) </summary>
        public User AccountHolder { get; set; }

        /// <summary> Количество имеющихся у пользователя бонусов </summary>
        public double BonusCount { get; set; }

        /// <summary> Заказы </summary>
        public IEnumerable<Order> Orders { get; set; }

        /// <summary> Корзина </summary>
        public IEnumerable<ProductInBusket> Busket { get; set; }

        /// <summary> Адрес доставки </summary>
        public string AddressDelivery { get; set; }
    }
}

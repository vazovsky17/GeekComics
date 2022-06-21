using System.ComponentModel.DataAnnotations.Schema;

namespace GeekComics.Domain.Models
{
    /// <summary> Действие с бонусами </summary>
    public class BonusAction : DomainObject
    {
        /// <summary> Количество бонусов </summary>
        public double BonusCount { get; set; }

        /// <summary> Начислены ли бонусы (если false, то списаны) </summary>
        public bool IsAccrual { get; set; }
    }
}

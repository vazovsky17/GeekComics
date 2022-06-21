namespace GeekComics.Domain.Models
{
    /// <summary> Сотрудник </summary>
    public class Employee : DomainObject
    {
        /// <summary> Аккаунт, принадлежащий сотруднику </summary>
        public Account Account { get; set; }

        /// <summary> Зарплата сотрудника </summary>
        public double Salary { get; set; }

        /// <summary> Дата принятия на работу </summary>
        public double DateEmployment { get; set; }
    }
}

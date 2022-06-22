namespace GeekComics.Domain.Models
{
    /// <summary> Данные пользователя </summary>
    public class User : DomainObject
    {
        /// <summary> Логин для авторизации </summary>
        public string Username { get; set; }

        /// <summary> Пароль для авторизации </summary>
        public string PasswordHash { get; set; }
    }
}

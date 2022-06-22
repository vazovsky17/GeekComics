using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.AuthentificationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        UsernameAlreadyExists,
        InvalidAdministrationCode
    }
    public interface IAuthenticationService
    {
        /// <summary>
        /// Вход в аккаунт
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Аккаунт</returns>
        /// <exception cref="UserNotFoundException">Пользователь не существует.</exception>
        /// <exception cref="InvalidPasswordException">Неверный пароль.</exception>
        /// <exception cref="Exception">Вход не удался.</exception>
        Task<Account> Login(string username, string password, string? administrationCode);


        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="confirmPassword">Подтверждение пароля</param>
        /// <param name="role">Роль</param>
        /// <returns>Результат регистрации</returns>
        /// <exception cref="Exception">Регистрация не удалась.</exception>
        Task<RegistrationResult> Register(string username, string password, string confirmPassword, Role role, string? administrationCode);
    }
}

using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services.AuthentificationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="confirmPassword">Подтверждение пароля</param>
        /// <returns>Результат регистрации</returns>
        /// <exception cref="Exception">Регистрация не удалась.</exception>
        Task<RegistrationResult> Register(string username, string password, string confirmPassword);

        /// <summary>
        /// Вход в аккаунт
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Аккаунт</returns>
        /// <exception cref="UserNotFoundException">Пользователь не существует.</exception>
        /// <exception cref="InvalidPasswordException">Неверный пароль.</exception>
        /// <exception cref="Exception">Вход не удался.</exception>
        Task<Account> Login(string username, string password);

    }
}

using System;
using System.Threading.Tasks;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services.AuthentificationServices;

namespace GeekComics.WPF.State.Authentificators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        /// <summary>
        /// Регистрация аккаунта
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="confirmPassword">Подтверждение пароля</param>
        /// <returns>Результат регистрации</returns>
        Task<RegistrationResult> Register(string username, string password, string confirmPassword, Role role);

        /// <summary>
        /// Вход в аккуант
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException">Пользователь не найден.</exception>
        /// <exception cref="InvalidPasswordException">Пароль не верный.</exception>
        /// <exception cref="Exception">Вход не удался.</exception>
        Task Login(string username, string password);

        void Logout();
    }
}

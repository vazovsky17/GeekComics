namespace GeekComics.Domain.Exceptions
{
    /// <summary>
    /// Исключение, вызванное, если пользователь с таким юзернеймом не найден
    /// </summary>
    public class UserNotFoundException : Exception
    {
        public string Username { get; set; }

        public UserNotFoundException(string username)
        {
            Username = username;
        }

        public UserNotFoundException(string message, string username) : base(message)
        {
            Username = username;
        }

        public UserNotFoundException(string message, Exception innerException, string username) : base(message, innerException)
        {
            Username = username;
        }
    }
}

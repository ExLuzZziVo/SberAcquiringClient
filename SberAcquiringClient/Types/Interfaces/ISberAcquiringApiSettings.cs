namespace SberAcquiringClient.Types.Interfaces
{
    /// <summary>
    /// Данные, необходимые для работы с платежным шлюзом
    /// </summary>
    public interface ISberAcquiringApiSettings
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// Адрес платежного шлюза
        /// </summary>
        string ApiHost { get; set; }
    }
}
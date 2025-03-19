using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса аутентификации пользователей.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Регистрирует нового пользователя асинхронно и возвращает токен аутентификации.
    /// </summary>
    /// <param name="email">Электронная почта нового пользователя.</param>
    /// <param name="username">Имя пользователя нового пользователя.</param>
    /// <param name="password">Пароль нового пользователя.</param>
    /// <returns>DTO (Data Transfer Object) токена аутентификации.</returns>
    Task<TokenDto> RegisterAsync(string email, string username, string password);

    /// <summary>
    /// Аутентифицирует пользователя по указанному логину и паролю и возвращает токен аутентификации.
    /// </summary>
    /// <param name="login">Логин пользователя (электронная почта или имя пользователя).</param>
    /// <param name="password">Пароль пользователя.</param>
    /// <returns>DTO (Data Transfer Object) токена аутентификации.</returns>
    Task<TokenDto> LoginAsync(string login, string password);
}
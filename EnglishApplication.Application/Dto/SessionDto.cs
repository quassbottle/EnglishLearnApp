using System.Collections.Generic;

namespace EnglishApplication.Application.Dto;

/// <summary>
/// DTO (Data Transfer Object) для представления данных сессии.
/// </summary>
public class SessionDto
{
    /// <summary>
    /// Идентификатор сессии.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Коллекция раундов, связанных с сессией.
    /// </summary>
    public ICollection<RoundDto> Rounds { get; set; }

    /// <summary>
    /// Флаг, указывающий, активна ли сессия.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Идентификатор пользователя, связанного с сессией.
    /// </summary>
    public int UserId { get; set; }
}
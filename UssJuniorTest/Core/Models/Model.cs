using System.Text.Json.Serialization;

namespace UssJuniorTest.Core.Models;

/// <summary>
/// Базовая модель для всех сущностей.
/// </summary>
public abstract class Model
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [JsonIgnore]
    public long Id { get; set; }
}
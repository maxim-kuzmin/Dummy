namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных одиночного фиктивного предмета.
/// </summary>
public record DummyItemSingleDTO
{
  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;
}

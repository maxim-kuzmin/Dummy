namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных фиктивного предмета.
/// </summary>
public record DummyItemSingleDTO
{  
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

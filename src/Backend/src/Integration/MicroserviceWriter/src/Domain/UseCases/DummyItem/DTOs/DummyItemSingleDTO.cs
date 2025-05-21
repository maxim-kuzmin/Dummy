namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
/// <param name="Name">Имя.</param>
public record DummyItemSingleDTO(
  long Id,
  string ConcurrencyToken,
  string Name);

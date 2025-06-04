namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных страницы фиктивных предметов.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record DummyItemPageDTO(
  List<DummyItemSingleDTO> Items,
  long TotalCount) : PageDTO<DummyItemSingleDTO, long>(Items, TotalCount);

namespace Makc.Dummy.Gateway.DomainUseCasesForMicroserviceWriter.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record DummyItemListDTO(
  List<DummyItemSingleDTO> Items,
  long TotalCount) : ListDTO<DummyItemSingleDTO, long>(Items, TotalCount);

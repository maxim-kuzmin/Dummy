namespace Makc.Dummy.Gateway.DomainUseCasesForMicroserviceWriter.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemSingleDTO(long Id, string Name, string ConcurrencyToken);

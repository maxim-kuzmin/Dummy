namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных действия по получению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemSingleDTO(long Id, string Name, Guid ConcurrencyToken);

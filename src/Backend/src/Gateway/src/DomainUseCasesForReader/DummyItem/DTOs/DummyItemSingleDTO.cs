namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных действия по получению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemSingleDTO(string? ObjectId, long Id, string Name, string ConcurrencyToken);

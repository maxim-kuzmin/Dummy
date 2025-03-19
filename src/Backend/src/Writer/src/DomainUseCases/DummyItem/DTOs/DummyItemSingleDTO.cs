namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных одиночного фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен конкуренции.</param>
public record DummyItemSingleDTO(long Id, string Name, Guid ConcurrencyToken);

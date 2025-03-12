namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных одиночного фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemSingleDTO(long Id, string Name);

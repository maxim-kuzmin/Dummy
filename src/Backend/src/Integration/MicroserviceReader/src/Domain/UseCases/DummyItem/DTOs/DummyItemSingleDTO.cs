namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.DummyItem.DTOs;

/// <summary>
/// Объект передачи данных одиночного фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemSingleDTO(string? ObjectId, long Id, string Name, string ConcurrencyToken);

namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Command.Sections;

/// <summary>
/// Раздел данных команды фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemCommandDataSection(
  long Id,
  string Name,
  string ConcurrencyToken);

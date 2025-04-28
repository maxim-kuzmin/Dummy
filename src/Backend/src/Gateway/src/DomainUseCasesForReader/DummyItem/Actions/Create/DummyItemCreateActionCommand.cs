namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.Create;

/// <summary>
/// Команда действия по созданию фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemCreateActionCommand(
  long Id,
  string Name,
  string ConcurrencyToken) : ICommand<Result<DummyItemSingleDTO>>;

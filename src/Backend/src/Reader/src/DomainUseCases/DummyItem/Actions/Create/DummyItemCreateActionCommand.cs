namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Create;

/// <summary>
/// Команда действия по созданию фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен конкуренции.</param>
public record DummyItemCreateActionCommand(  
  long Id,
  string Name,
  Guid ConcurrencyToken) : ICommand<Result<DummyItemSingleDTO>>;

namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IDummyItemCommandService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    Result result = null!;

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var resultForDelete = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

      result = resultForDelete.Data;

      await _service.OnEntityChanged(resultForDelete.Payloads, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return result;
  }
}

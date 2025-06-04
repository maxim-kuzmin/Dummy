namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemSaveActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IDummyItemCommandService _service) :
  ICommandHandler<DummyItemSaveActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    Result<DummyItemSingleDTO> result = null!;

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var resultForSave = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

      result = resultForSave.Data;

      await _service.OnEntityChanged(resultForSave.Payloads, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return result;
  }
}

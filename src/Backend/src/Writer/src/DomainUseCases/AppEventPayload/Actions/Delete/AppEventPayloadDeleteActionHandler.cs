namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventPayloadDeleteActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IAppEventPayloadFactory _factory,
  IAppEventPayloadRepository _repository) :
  ICommandHandler<AppEventPayloadDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppEventPayloadDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    var aggregateResult = aggregate.GetResultToDelete();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Data.Deleted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await _repository.DeleteAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }
}

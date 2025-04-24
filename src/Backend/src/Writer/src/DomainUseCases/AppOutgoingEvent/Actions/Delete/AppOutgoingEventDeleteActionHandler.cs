namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventDeleteActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventFactory _factory,
  IAppOutgoingEventEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutgoingEventDeleteActionCommand request, CancellationToken cancellationToken)
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

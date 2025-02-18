namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventUpdateActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IAppEventFactory _factory,
  IAppEventRepository _repository) :
  ICommandHandler<AppEventUpdateActionCommand, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Handle(
    AppEventUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateIsPublished(request.IsPublished);
    aggregate.UpdateName(request.Name);

    var aggregateResult = aggregate.GetResultToUpdate();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppEventSingleDTO();

    return Result.Success(dto);
  }
}

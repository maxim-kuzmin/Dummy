namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventPayloadUpdateActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IAppEventPayloadModelFactory _factory,
  IAppEventPayloadEntityRepository _repository) :
  ICommandHandler<AppEventPayloadUpdateActionCommand, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateAppEventId(request.AppEventId);
    aggregate.UpdateData(request.Data);

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

    var dto = entity.ToAppEventPayloadSingleDTO();

    return Result.Success(dto);
  }
}

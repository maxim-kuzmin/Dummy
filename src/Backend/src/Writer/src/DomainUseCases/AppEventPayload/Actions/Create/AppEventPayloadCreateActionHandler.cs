namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;

/// <summary>
/// Обработчик действия по созданию полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventPayloadCreateActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IAppEventPayloadFactory _factory,
  IAppEventPayloadRepository _repository) :
  ICommandHandler<AppEventPayloadCreateActionCommand, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateAppEventId(request.AppEventId);
    aggregate.UpdateData(request.Data);

    var aggregateResult = aggregate.GetResultToCreate();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    var entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppEventPayloadSingleDTO();

    return Result.Success(dto);
  }
}

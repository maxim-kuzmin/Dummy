namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
public class AppEventPayloadGetActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventPayloadGetActionFactory _factory) :
  IQueryHandler<AppEventPayloadGetActionQuery, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dbCommand = _factory.CreateDbCommand(request);

    var task = _appDbQueryContext.GetFirstOrDefaultAsync<AppEventPayloadSingleDTO>(dbCommand, cancellationToken);

    var dto = await task.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}

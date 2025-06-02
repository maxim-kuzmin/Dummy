namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetPageActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetPageActionRequest, Result<AppOutgoingEventPageDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPageDTO>> Handle(
    AppOutgoingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}

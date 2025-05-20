namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetListActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetListActionRequest, Result<AppIncomingEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventListDTO>> Handle(
    AppIncomingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken);

    return Result.Success(result);
  }
}

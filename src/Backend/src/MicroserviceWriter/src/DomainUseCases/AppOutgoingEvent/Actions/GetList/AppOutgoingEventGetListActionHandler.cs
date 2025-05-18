namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetListActionRequest, Result<AppOutgoingEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventListDTO>> Handle(
    AppOutgoingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken);

    return Result.Success(result);
  }
}

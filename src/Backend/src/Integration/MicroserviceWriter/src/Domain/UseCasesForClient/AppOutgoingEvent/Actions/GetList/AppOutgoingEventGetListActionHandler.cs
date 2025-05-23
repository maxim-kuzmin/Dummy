namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetListActionRequest, Result<AppOutgoingEventPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventPageDTO>> Handle(
    AppOutgoingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}

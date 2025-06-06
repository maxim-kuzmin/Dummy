﻿namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetListActionRequest, Result<List<AppOutgoingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public async Task<Result<List<AppOutgoingEventSingleDTO>>> Handle(
    AppOutgoingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetList(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}

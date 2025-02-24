﻿namespace Makc.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка событий приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventGetListEndpointRequest, IEnumerable<AppEventListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppEventGetListEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    AppEventGetListActionQuery query = request.ToAppEventGetListActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

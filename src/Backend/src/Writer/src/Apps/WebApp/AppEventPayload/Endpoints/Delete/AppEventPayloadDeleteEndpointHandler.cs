﻿namespace Makc.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления полезной нагрузки события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppEventPayloadDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppEventPayloadDeleteActionCommand, AppEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppEventPayloadDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppEventPayloadDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

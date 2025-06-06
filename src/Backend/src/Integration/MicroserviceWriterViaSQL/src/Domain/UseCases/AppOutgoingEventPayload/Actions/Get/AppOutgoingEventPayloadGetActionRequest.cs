﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetActionRequest(AppOutgoingEventPayloadSingleQuery Query) :
  IQuery<Result<AppOutgoingEventPayloadSingleDTO>>;

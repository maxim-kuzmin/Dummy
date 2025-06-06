﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Запрос действия по удалению исходящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutgoingEventDeleteActionRequest(AppOutgoingEventDeleteCommand Command) :
  ICommand<Result>;

﻿namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.Model.AppIncomingEventPayload.Entity.Db.NoSQL;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки входящего события приложения.
/// </summary>
public abstract record AppIncomingEventPayloadEntityDbNoSQLSettings : AppIncomingEventPayloadEntitySettings
{
  /// <summary>
  /// Таблица.
  /// </summary>
  public string Collection { get; protected set; } = string.Empty;
}

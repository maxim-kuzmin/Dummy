﻿namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public record AppDbSettings : AppDbSettingsBase
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettings()
  {
    Schema = "writer";
    Entities = new AppDbSettingsEntities(Schema);    
  }
}

namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEventPayload.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventPayloadGetActionFactory(AppDbSettings _appDbSettings) : IAppEventPayloadGetActionFactory
{  
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppEventPayloadGetActionQuery query)
  {
    DbSQLCommand result = new();

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    result.TextBuilder.Append($$"""
select
  "{{sAppEventPayload.ColumnForId}}" "Id",
  "{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  "{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
where
  "{{sAppEventPayload.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }
}

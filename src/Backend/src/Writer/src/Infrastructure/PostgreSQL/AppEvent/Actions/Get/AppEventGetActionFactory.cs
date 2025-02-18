namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventGetActionFactory(AppDbSettings _appDbSettings) : IAppEventGetActionFactory
{  
  /// <inheritdoc/>
  public DbCommand CreateDbCommand(AppEventGetActionQuery query)
  {
    DbCommand result = new();

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    result.TextBuilder.Append($$"""
select
  "{{sAppEvent.ColumnForId}}" "Id",
  "{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  "{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
where
  "{{sAppEvent.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }
}

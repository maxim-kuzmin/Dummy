namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.DummyItem.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemGetActionFactory(AppDbSettings _appDbSettings) : IDummyItemGetActionFactory
{  
  /// <inheritdoc/>
  public DbCommand CreateDbCommand(DummyItemGetActionQuery query)
  {
    DbCommand result = new();

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.Append($$"""
select
  "{{sDummyItem.ColumnForId}}" "Id",
  "{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }
}

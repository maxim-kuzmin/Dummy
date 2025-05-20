namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Db.SQL.Factories;

/// <summary>
/// Интерфейс фабрики команд базы данных SQL полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadDbSQLCommandFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbSQLCommand CreateDbCommand(AppOutgoingEventPayloadSingleQuery query);

  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="filter">Фильтр.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbSQLCommand CreateDbCommandForFilter(AppOutgoingEventPayloadQueryFilterSection? filter);

  /// <summary>
  /// Создать базы данных для элементов.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <param name="sort">Сортировка.</param>
  /// <param name="page">Страница.</param>  
  /// <returns>Команда базы данных для элементов.</returns>
  DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    QueryPageSection? page = null);

  /// <summary>
  /// Создать базы данных для общего количества.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <returns>Команда базы данных для общего количества.</returns>
  DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter);
}

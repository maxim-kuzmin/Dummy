namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Db.SQL.Factories;

/// <summary>
/// Интерфейс фабрики команд базы данных SQL исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventDbSQLCommandFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbSQLCommand CreateDbCommand(AppOutgoingEventSingleQuery query);

  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbSQLCommand CreateDbCommand(AppOutgoingEventUnpublishedListQuery query);

  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="filter">Фильтр.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbSQLCommand CreateDbCommandForFilter(AppOutgoingEventQueryFilterSection? filter);

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

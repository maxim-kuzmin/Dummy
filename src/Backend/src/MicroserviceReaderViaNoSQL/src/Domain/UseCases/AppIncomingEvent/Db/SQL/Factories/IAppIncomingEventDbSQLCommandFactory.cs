namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Db.SQL.Factories;

/// <summary>
/// Интерфейс фабрики команд базы данных SQL входящего события приложения.
/// </summary>
public interface IAppIncomingEventDbSQLCommandFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbSQLCommand CreateDbCommand(AppIncomingEventSingleQuery query);

  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbSQLCommand CreateDbCommandForFilter(AppIncomingEventPageQuery query);

  /// <summary>
  /// Создать команду базы данных для элементов.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <param name="page">Страница.</param>
  /// <param name="sort">Сортировка.</param>
  /// <returns>Команда базы данных для элементов.</returns>
  DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QueryPageSection? page,
    QuerySortSection? sort);

  /// <summary>
  /// Создать команду базы данных для общего количества.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <returns>Команда базы данных для общего количества.</returns>
  DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter);
}

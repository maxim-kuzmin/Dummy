namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.DummyItem.Db.SQL.Factories;

/// <summary>
/// Интерфейс фабрики команд базы данных SQL фиктивного предмета.
/// </summary>
public interface IDummyItemDbSQLCommandFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbSQLCommand CreateDbCommand(DummyItemSingleQuery query);

  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="filter">Фильтр.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbSQLCommand CreateDbCommandForFilter(DummyItemQueryFilterSection? filter);

  /// <summary>
  /// Создать команду базы данных для элементов.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <param name="sort">Сортировка.</param>
  /// <param name="maxCount">Максимальное количество.</param>  
  /// <returns>Команда базы данных для элементов.</returns>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    int maxCount);

  /// <summary>
  /// Создать команду базы данных для элементов.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <param name="sort">Сортировка.</param>
  /// <param name="page">Страница.</param>  
  /// <returns>Команда базы данных для элементов.</returns>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    QueryPageSection? page);

  /// <summary>
  /// Создать команду базы данных для общего количества.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <returns>Команда базы данных для общего количества.</returns>
  DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter);
}

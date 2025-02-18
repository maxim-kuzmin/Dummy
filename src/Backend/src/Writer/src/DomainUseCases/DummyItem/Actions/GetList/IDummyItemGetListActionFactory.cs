namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Интерфейс фабрики действия по получению списка фиктивных предметов.
/// </summary>
public interface IDummyItemGetListActionFactory
{
  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbCommand CreateDbCommandForFilter(DummyItemGetListActionQuery query);

  /// <summary>
  /// Создать базы данных для элементов.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <param name="page">Страница.</param>
  /// <returns>Команда базы данных для элементов.</returns>
  DbCommand CreateDbCommandForItems(DbCommand dbCommandForFilter, QueryPage? page);

  /// <summary>
  /// Создать базы данных для общего количества.
  /// </summary>
  /// <param name="dbCommandForFilter">Команда базы данных для фильтра.</param>
  /// <returns>Команда базы данных для общего количества.</returns>
  DbCommand CreateDbCommandForTotalCount(DbCommand dbCommandForFilter);
}

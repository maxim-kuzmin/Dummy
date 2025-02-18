namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Интерфейс фабрики действия по получению списка событий приложения.
/// </summary>
public interface IAppEventGetListActionFactory
{
  /// <summary>
  /// Создать команду базы данных для фильтра.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных для фильтра.</returns>
  DbCommand CreateDbCommandForFilter(AppEventGetListActionQuery query);

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

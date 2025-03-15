namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Db;

/// <summary>
/// Расширения базы данных.
/// </summary>
public static class DbExtensions
{
  /// <summary>
  /// Взять страницу.
  /// </summary>
  /// <typeparam name="TEntity">Тип сущности.</typeparam>
  /// <param name="found">Найденное.</param>
  /// <param name="page">Страница.</param>
  /// <returns>Страница найденного.</returns>
  public static IFindFluent<TEntity, TEntity> TakePage<TEntity>(
    this IFindFluent<TEntity, TEntity> found,
    QueryPageSection? page)
  {
    if (page == null)
    {
      return found;
    }

    if (page.Number > 0)
    {
      found = found.Skip((page.Number - 1) * page.Size);
    }

    if (page.Size > 0)
    {
      found = found.Limit(page.Size);
    }

    return found;
  }

  /// <summary>
  /// Сортировать.
  /// </summary>
  /// <typeparam name="TEntity">Тип сущности.</typeparam>
  /// <param name="found">Найденное.</param>
  /// <param name="sort">Сортировка.</param>
  /// <param name="defaultSort">Сортировка по умолчанию.</param>
  /// <param name="funcToCreateSortFieldExpression">Функция создания выражения поля сортировки.</param>
  /// <returns>Отсортированнеое найденное.</returns>
  public static IFindFluent<TEntity, TEntity> Sort<TEntity>(
    this IFindFluent<TEntity, TEntity> found,
    QuerySortSection? sort,
    QuerySortSection defaultSort,
    Func<string, Expression<Func<TEntity, object>>> funcToCreateSortFieldExpression
    )
  {
    if (sort == null)
    {
      sort = defaultSort;
    }

    var sortFieldExpression = funcToCreateSortFieldExpression.Invoke(sort.Field);

    return sort.IsDesc ? found.SortByDescending(sortFieldExpression) : found.SortBy(sortFieldExpression);
  }
}

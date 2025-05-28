namespace Makc.Dummy.Shared.Domain.UseCases.Query;

/// <summary>
/// Расширения запроса.
/// </summary>
public static class QueryExtensions
{
  /// <summary>
  /// Равно полю сортировки.
  /// </summary>
  /// <param name="left">Поле сортировки, которое сравнивается.</param>
  /// <param name="right">Поле сортировки, с которым идёт сранение.</param>
  /// <returns>Если равно, то true, иначе - false. </returns>
  public static bool EqualsToSortField(this string left, string right)
  {
    return left.Equals(right, StringComparison.InvariantCultureIgnoreCase);
  }

  /// <summary>
  /// Преобразовать к номеру страницы.
  /// </summary>
  /// <param name="count">Количество.</param>
  /// <param name="pageSize">Размер страницы.</param>
  /// <returns>Номер страницы.</returns>
  public static int ToPageNumber(this long count, int pageSize)
  {
    if (count > 0)
    {
      if (count > pageSize)
      {
        return (int)Math.Ceiling((decimal)count / pageSize);
      }
      else
      {
        return 1;
      }
    }
    else
    {
      return 1;
    }
  }

  /// <summary>
  /// Преобразовать в пропуск.
  /// </summary>
  /// <param name="page">Страница.</param>
  /// <returns>Пропуск.</returns>
  public static int ToSkip(this QueryPageSection page)
  {
    return (page.Number - 1) * page.Size;
  }
}

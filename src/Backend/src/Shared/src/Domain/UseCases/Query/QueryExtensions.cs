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
}

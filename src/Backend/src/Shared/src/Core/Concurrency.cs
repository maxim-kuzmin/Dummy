namespace Makc.Dummy.Shared.Core;

/// <summary>
/// Параллелизм.
/// </summary>
public static class Concurrency
{
  /// <summary>
  /// Создать токен.
  /// </summary>
  /// <returns>Токен параллелизма.</returns>
  public static string CreateToken()
  {
    return Guid.NewGuid().ToString();
  }
}

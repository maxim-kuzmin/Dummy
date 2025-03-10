namespace Makc.Dummy.Shared.Infrastructure.MongoDB;

/// <summary>
/// Расширения.
/// </summary>
public static class Extensions
{
  /// <summary>
  /// Настроить.
  /// </summary>
  /// <param name="entityConfigurations">Конфигурации сущностей.</param>
  public static void Configure(this IEnumerable<IEntityConfiguration> entityConfigurations)
  {
    foreach (var entityConfiguration in entityConfigurations)
    {
      entityConfiguration.Configure();
    }
  }
}

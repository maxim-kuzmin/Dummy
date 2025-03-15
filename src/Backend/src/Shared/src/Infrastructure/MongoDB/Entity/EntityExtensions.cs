namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Entity;

/// <summary>
/// Расширения сущности.
/// </summary>
public static class EntityExtensions
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

namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел аутентификации в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsAuthenticationSection
{
  /// <summary>
  /// Издатель.
  /// </summary>
  public string Issuer { get; set; } = string.Empty;

  /// <summary>
  /// Аудитория.
  /// </summary>
  public string Audience { get; set; } = string.Empty;

  /// <summary>
  /// Ключ.
  /// </summary>
  public string Key { get; set; } = string.Empty;

  /// <summary>
  /// Получить симметричный ключ безопасности.
  /// </summary>
  /// <returns>Симметричный ключ безопасности.</returns>
  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    var keyBytes = Encoding.UTF8.GetBytes(Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}

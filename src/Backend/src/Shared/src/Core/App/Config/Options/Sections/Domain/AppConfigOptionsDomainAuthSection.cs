namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Domain;

/// <summary>
/// Раздел аутентификации в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAuthSection
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
  /// Тип.
  /// </summary>
  public AppConfigOptionsAuthenticationEnum Type { get; set; } = AppConfigOptionsAuthenticationEnum.JWT;

  /// <summary>
  /// Получить симметричный ключ безопасности.
  /// </summary>
  /// <returns>Симметричный ключ безопасности.</returns>
  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    var keyBytes = Encoding.UTF8.GetBytes(Key);

    return new SymmetricSecurityKey(keyBytes);
  }

  /// <summary>
  /// Создать токен доступа.
  /// </summary>
  /// <param name="name">Имя.</param>
  /// <param name="roles">Роли.</param>
  /// <returns>Токен доступа.</returns>
  public string? CreateAccessToken(string? name, IEnumerable<string>? roles)
  {
    if (name == null)
    {
      return null;
    }

    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, name)
    };

    if (roles != null)
    {
      foreach (var role in roles)
      {
        claims.Add(new(ClaimTypes.Role, role));
      }
    }

    var issuerSigningKey = GetSymmetricSecurityKey();

    var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

    var expires = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

    var token = new JwtSecurityToken(
      issuer: Issuer,
      audience: Audience,
      claims: claims,
      expires: expires,
      signingCredentials: signingCredentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}

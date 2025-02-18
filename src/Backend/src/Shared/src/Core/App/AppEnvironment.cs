namespace Makc.Dummy.Shared.Core.App;

/// <summary>
/// Окружение приложения.
/// </summary>
public class AppEnvironment
{
  /// <summary>
  /// Загрузить переменные.
  /// </summary>
  public static void LoadVariables()
  {
    var loader = new EnvLoader();

    string? env = GetVariable("MY_ENVIRONMENT");

    if (string.IsNullOrWhiteSpace(env))
    {
      env = GetVariable("ASPNETCORE_ENVIRONMENT");
    }

    if (string.IsNullOrWhiteSpace(env))
    {
      env = GetVariable("DOTNET_ENVIRONMENT");
    }

    if (!string.IsNullOrWhiteSpace(env))
    {
      loader.SetDefaultEnvFileName($".env.{env}");
    }

    loader.Load();
  }

  private static string? GetVariable(string variable)
  {
    var result = Environment.GetEnvironmentVariable(variable);

    if (!string.IsNullOrWhiteSpace(result))
    {
      result = result.ToLower();
    }

    return result;
  }
}

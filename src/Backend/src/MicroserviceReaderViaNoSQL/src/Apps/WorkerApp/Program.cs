var logger = AppLogger.Create<Program>();

try
{
  logger.LogInformation("Starting application");

  AppEnvironment.LoadVariables();

  var appBuilder = Host.CreateApplicationBuilder(args);

  var app = appBuilder.BuildApp(logger);

  app.Run();
}
catch (Exception ex)
{
  logger.LogCritical(ex, "Application terminated unexpectedly");
}
finally
{
  AppLogger.CloseAndFlush();
}

public partial class Program { }

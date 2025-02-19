namespace Makc.Dummy.Shared.Infrastructure.Core.App.Logger.Funcs;

/// <summary>
/// Функция настройки логгера приложения.
/// </summary>
/// <param name="serviceProvider">Поставщик сервисов.</param>
/// <param name="config">Конфигурация.</param>
/// <returns>Конфигурация.</returns>
public delegate LoggerConfiguration AppLoggerFuncToConfigure(
  IServiceProvider serviceProvider,
  LoggerConfiguration config);

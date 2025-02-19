namespace Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetry.App.Tracing.Funcs;

/// <summary>
/// Функция настройки отслеживания приложения.
/// </summary>
/// <param name="providerBuilder">Построитель поставщика.</param>
/// <returns>Построитель поставщика.</returns>
public delegate TracerProviderBuilder AppTracingFuncToConfigure(TracerProviderBuilder providerBuilder);

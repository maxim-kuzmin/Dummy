namespace Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetry.App.Metrics.Funcs;

/// <summary>
/// Функция настройки измерений приложения.
/// </summary>
/// <param name="providerBuilder">Построитель поставщика.</param>
/// <returns>Построитель поставщика.</returns>
public delegate MeterProviderBuilder AppMetricsFuncToConfigure(MeterProviderBuilder providerBuilder);

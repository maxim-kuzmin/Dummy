namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadGetActionFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbCommand CreateDbCommand(AppEventPayloadGetActionQuery query);
}

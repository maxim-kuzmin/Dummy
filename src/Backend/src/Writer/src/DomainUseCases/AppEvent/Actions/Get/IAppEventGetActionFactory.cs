namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению события приложения.
/// </summary>
public interface IAppEventGetActionFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL.</returns>
  DbSQLCommand CreateDbCommand(AppEventGetActionQuery query);
}

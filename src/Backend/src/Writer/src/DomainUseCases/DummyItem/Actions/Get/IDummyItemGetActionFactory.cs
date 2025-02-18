namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению фиктивного предмета.
/// </summary>
public interface IDummyItemGetActionFactory
{
  /// <summary>
  /// Создать команду базы данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Команда базы данных.</returns>
  DbCommand CreateDbCommand(DummyItemGetActionQuery query);
}

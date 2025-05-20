namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда обновления свойства по идентификаторам исходящих событий приложения.
/// </summary>
/// <typeparam name="TPropertyValue">Тип значения звойства.</typeparam>
/// <param name="Ids">Идентификаторы.</param>
/// <param name="PropertyValue">Значение свойства.</param>
public record AppOutgoingEventUpdatePropertyByIdsCommand<TPropertyValue>(
  IEnumerable<long> Ids,
  TPropertyValue PropertyValue) : UpdatePropertyByIdsCommand<long, TPropertyValue>(Ids, PropertyValue);

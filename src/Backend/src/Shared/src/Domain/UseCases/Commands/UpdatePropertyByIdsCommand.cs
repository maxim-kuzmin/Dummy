namespace Makc.Dummy.Shared.Domain.UseCases.Commands;

/// <summary>
/// Команда обновления свойства по идентификаторам.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
/// <typeparam name="TPropertyValue">Тип значения свойства.</typeparam>
/// <param name="Ids">Идентификаторы.</param>
/// <param name="PropertyValue">Значение свойства.</param>
public record UpdatePropertyByIdsCommand<TId, TPropertyValue>(IEnumerable<TId> Ids, TPropertyValue PropertyValue);

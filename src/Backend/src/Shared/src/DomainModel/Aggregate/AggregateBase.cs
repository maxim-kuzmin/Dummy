namespace Makc.Dummy.Shared.DomainModel.Aggregate;

/// <summary>
/// Основа агрегата.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class AggregateBase<TEntity, TPrimaryKey>
  where TEntity : class, IEntityBase<TPrimaryKey>, new()
  where TPrimaryKey : IEquatable<TPrimaryKey>
{
  private readonly TEntity? _entityToChange;

  private readonly AppEventPayloadWithDataAsDictionary _payload;

  private TEntity? _entityToUpdate;

  /// <summary>
  /// Ошибки обновления.
  /// </summary>
  protected HashSet<AppError> UpdateErrors { get; } = [];

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  public AggregateBase(TEntity? entityToChange = null)
  {
    _entityToChange = entityToChange;

    _payload = new()
    {
      EntityName = GetEntityName()
    };
  }

  /// <summary>
  /// Добавить изменённое свойство.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  /// <param name="propertyValueAsString">Значение свойства в виде строки.</param>
  protected void AddChangedProperty(string propertyName, string? propertyValueAsString)
  {
    _payload.Data[propertyName] = propertyValueAsString;
  }

  /// <summary>
  /// Получить результат для создания.
  /// </summary>
  /// <returns>Результат для создания.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToCreate()
  {
    if (_entityToUpdate == null)
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    OnGetResultToCreate(_entityToUpdate);

    return new AggregateResult<EntityChange<TEntity>>(new(_entityToUpdate, null), UpdateErrors);
  }

  /// <summary>
  /// Получить результат для удаления.
  /// </summary>
  /// <returns>Результат для удаления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToDelete()
  {
    if (_entityToChange == null || _entityToChange.GetPrimaryKeyOrDefault().Equals(_entityToChange.GetDefaultPrimaryKey()))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    OnGetResultToDelete(_entityToChange);

    return new AggregateResult<EntityChange<TEntity>>(new(null, _entityToChange));
  }

  /// <summary>
  /// Получить результат для обновления.
  /// </summary>
  /// <returns>Результат для обновления.</returns>
  public virtual AggregateResult<EntityChange<TEntity>> GetResultToUpdate()
  {
    if (_entityToChange == null || _entityToChange.GetPrimaryKeyOrDefault().Equals(_entityToChange.GetDefaultPrimaryKey()))
    {
      return new AggregateResult<EntityChange<TEntity>>(null);
    }

    var deleted = (TEntity)_entityToChange.DeepCopy();

    OnGetResultToUpdate(_entityToChange);

    return new AggregateResult<EntityChange<TEntity>>(new(_entityToChange, deleted), UpdateErrors);
  }

  /// <summary>
  /// Получить имя сущности.
  /// </summary>
  /// <returns>Имя сущности.</returns>
  protected abstract string GetEntityName();

  /// <summary>
  /// Получить сушность для обновления.
  /// </summary>
  /// <returns>Сущность для обновления.</returns>
  protected TEntity GetEntityToUpdate()
  {
    _entityToUpdate ??= new TEntity();

    return _entityToUpdate;
  }

  /// <summary>
  /// Недействителен ли для обновления?
  /// </summary>
  /// <param name="aggregateResult">Результат агрегата.</param>
  /// <returns>Если недействителен для обновления, то true, иначе - false.</returns>
  protected bool IsInvalidToUpdate(AggregateResult<EntityChange<TEntity>> aggregateResult)
  {
    return aggregateResult.IsInvalid
      ||
      aggregateResult.Data?.Inserted == null
      ||
      aggregateResult.Data?.Deleted == null;
  }

  /// <summary>
  /// Есть ли изменённые свойства?
  /// </summary>
  /// <returns>Если есть изменённые свойства, то true, иначе - false.</returns>
  protected bool HasChangedProperties()
  {
    return _payload.Data.Count > 0;
  }

  /// <summary>
  /// Есть ли изменённое свойство?
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  /// <returns>Если значение свойства изменилось, то true, иначе - false.</returns>
  protected bool HasChangedProperty(string propertyName)
  {
    return _payload.Data.ContainsKey(propertyName);
  }

  /// <summary>
  /// Обработать событие получения результата для создания.
  /// </summary>
  /// <param name="entity">Обновляемая сущность.</param>
  protected virtual void OnGetResultToCreate(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для удаления.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  protected virtual void OnGetResultToDelete(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для обновления.
  /// </summary>
  /// <param name="entity">Обновляемая сущность.</param>
  protected virtual void OnGetResultToUpdate(TEntity entity)
  {
  }

  /// <summary>
  /// Подготовить изменённое свойство к обновлению.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  /// <param name="funcToCompare">Функция для сравнения.</param>
  /// <param name="actionToUpdate">Действие для обновления.</param>
  /// <returns>Если свойство обновилось, то true, иначе - false.</returns>
  protected bool PrepareChangedPropertyToUpdate(string propertyName, Func<bool> funcToCompare, Action actionToUpdate)
  {
    if (!HasChangedProperty(propertyName))
    {
      return false;
    }

    if (!funcToCompare.Invoke())
    {
      RemoveChangedProperty(propertyName);

      return false;
    }

    actionToUpdate.Invoke();

    return true;
  }

  /// <summary>
  /// Удалить изменённое свойство.
  /// </summary>
  /// <param name="propertyName">Имя свойства.</param>
  protected void RemoveChangedProperty(string propertyName)
  {
    _payload.Data.Remove(propertyName);
  }
}

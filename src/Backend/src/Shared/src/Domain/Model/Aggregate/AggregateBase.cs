namespace Makc.Dummy.Shared.Domain.Model.Aggregate;

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

  private readonly AppEventDictionaryPayload _payload;

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
  /// Получить результат для удаления.
  /// </summary>
  /// <returns>Результат для удаления.</returns>
  public virtual AggregateResult<TEntity> GetResultForDelete()
  {
    if (_entityToChange == null || _entityToChange.HasInvalidPrimaryKey())
    {
      return AggregateResult<TEntity>.CreateDefault();
    }

    OnGetResultForDelete(_entityToChange);

    _payload.EntityId = _entityToChange.GetPrimaryKeyAsString();

    _payload.EntityConcurrencyTokenToDelete = _entityToChange.GetConcurrencyToken();

    return new AggregateResult<TEntity>(_entityToChange, _payload);
  }

  /// <summary>
  /// Получить результат для вставки.
  /// </summary>
  /// <returns>Результат для вставки.</returns>
  public virtual AggregateResult<TEntity> GetResultForInsert()
  {
    if (_entityToUpdate == null)
    {
      return AggregateResult<TEntity>.CreateDefault();
    }

    OnGetResultForInsert(_entityToUpdate);

    _payload.EntityConcurrencyTokenToInsert = _entityToUpdate.GetConcurrencyToken();

    return new AggregateResult<TEntity>(_entityToUpdate, _payload, UpdateErrors);
  }

  /// <summary>
  /// Получить результат для обновления.
  /// </summary>
  /// <returns>Результат для обновления.</returns>
  public virtual AggregateResult<TEntity> GetResultForUpdate()
  {
    if (_entityToChange == null || _entityToChange.HasInvalidPrimaryKey())
    {
      return AggregateResult<TEntity>.CreateDefault();
    }

    _payload.EntityId = _entityToChange.GetPrimaryKeyAsString();

    _payload.EntityConcurrencyTokenToDelete = _entityToChange.GetConcurrencyToken();

    OnGetResultForUpdate(_entityToChange);
    
    _payload.EntityConcurrencyTokenToInsert = _entityToChange.GetConcurrencyToken();

    return new AggregateResult<TEntity>(_entityToChange, _payload, UpdateErrors);
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
  /// Есть ли изменённые свойства?
  /// </summary>
  /// <returns>Если есть изменённые свойства, то true, иначе - false.</returns>
  protected bool HasChangedProperties()
  {
    return _payload.Data.Count > 0;
  }
  
  /// <summary>
  /// Обработать событие получения результата для удаления.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  protected virtual void OnGetResultForDelete(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для вставки.
  /// </summary>
  /// <param name="entity">Вставляемая сущность.</param>
  protected virtual void OnGetResultForInsert(TEntity entity)
  {
  }

  /// <summary>
  /// Обработать событие получения результата для обновления.
  /// </summary>
  /// <param name="entity">Обновляемая сущность.</param>
  protected virtual void OnGetResultForUpdate(TEntity entity)
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
    if (!_payload.Data.ContainsKey(propertyName))
    {
      return false;
    }

    if (!funcToCompare.Invoke())
    {
      _payload.Data.Remove(propertyName);

      return false;
    }

    actionToUpdate.Invoke();

    return true;
  }
}

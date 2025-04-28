namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
public class DummyItemAggregate(
  DummyItemEntity? entityToChange,
  IDummyItemResources _resources) : AggregateBase<DummyItemEntity, string>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<DummyItemEntity>> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      bool isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.Name)) && inserted.Name != entity.Name)
      {
        inserted.Name = entity.Name;

        isOk = true;
      }

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<DummyItemEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить токен параллелизма.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateConcurrencyToken(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetIdIsInvalidErrorMessage();

      var appError = DummyItemErrorEnum.ConcurrencyTokenIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.ConcurrencyToken = value;

    MarkPropertyAsChanged(nameof(entity.ConcurrencyToken));
  }

  /// <summary>
  /// Обновить идентификатор.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateId(long value)
  {
    if (value < 0)
    {
      string errorMessage = _resources.GetIdIsInvalidErrorMessage();

      var appError = DummyItemErrorEnum.IdIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Id = value;
    entity.IdAsString = value.ToString();

    MarkPropertyAsChanged(nameof(entity.Id));
  }

  /// <summary>
  /// Обновить имя.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateName(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetNameIsEmptyErrorMessage();

      var appError = DummyItemErrorEnum.NameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Name = value;

    MarkPropertyAsChanged(nameof(entity.Name));
  }
}

namespace Makc.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemAggregate(
  DummyItemEntity? entityToChange,
  IDummyItemResources _resources,
  DummyItemEntitySettings _settings) : AggregateBase<DummyItemEntity, long>(entityToChange)
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

    int maxLength = _settings.MaxLengthForName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(maxLength);

      var appError = DummyItemErrorEnum.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Name = value;

    MarkPropertyAsChanged(nameof(entity.Name));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(DummyItemEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(DummyItemEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(DummyItemEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid().ToString();
  }
}

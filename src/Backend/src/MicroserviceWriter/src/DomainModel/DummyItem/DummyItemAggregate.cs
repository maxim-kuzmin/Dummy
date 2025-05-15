namespace Makc.Dummy.MicroserviceWriter.DomainModel.DummyItem;

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
  public sealed override AggregateResult<DummyItemEntity> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      var target = result.Entity!;

      var source = GetEntityToUpdate();

      bool isEntityChanged =
        PrepareChangedPropertyToUpdate(
          nameof(source.Name),
          () => target.Name != source.Name,
          () => target.Name = source.Name);

      if (isEntityChanged)
      {
        return result;
      }
    }

    return AggregateResult<DummyItemEntity>.CreateDefault();
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

    AddChangedProperty(nameof(entity.Name), entity.Name);
  }

  /// <inheritdoc/>
  protected sealed override string GetEntityName()
  {
    return "DummyItem";
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

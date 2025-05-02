namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Агрегат фиктивного предмета.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemAggregate(
  DummyItemEntity? entityToChange,
  IDummyItemResources _resources,
  DummyItemEntitySettings _settings) : AggregateBase<DummyItemEntity, string>(entityToChange)
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

      bool isNamePropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.Name),
        () => target.Name != source.Name,
        () => target.Name = source.Name);

      bool isEntityChanged = isNamePropertyChanged;

      if (isEntityChanged)
      {
        return result;
      }
    }

    return AggregateResult<DummyItemEntity>.CreateDefault();
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

    AddChangedProperty(nameof(entity.ConcurrencyToken), entity.ConcurrencyToken);
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

    AddChangedProperty(nameof(entity.Id), entity.Id.ToString());
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
  protected override string GetEntityName()
  {
    return "DummyItem";
  }
}

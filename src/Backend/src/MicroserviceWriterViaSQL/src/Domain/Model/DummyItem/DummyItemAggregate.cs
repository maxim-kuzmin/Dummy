namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.DummyItem;

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
  public sealed override AggregateResult<DummyItemEntity> GetResultForUpdate()
  {
    var result = base.GetResultForUpdate();

    if (result.IsInvalidForUpdate)
    {
      return result;
    }

    if (HasChangedProperties())
    {
      var target = result.Entity!;

      var source = GetEntityToUpdate();

      bool[] updates = [
        PrepareChangedPropertyToUpdate(
          nameof(source.Name),
          () => target.Name != source.Name,
          () => target.Name = source.Name)
        ];

      if (updates.Any(x => x == true))
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
  protected sealed override void OnGetResultForInsert(DummyItemEntity entity)
  {
    entity.ConcurrencyToken = Concurrency.CreateToken();
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultForUpdate(DummyItemEntity entity)
  {
    entity.ConcurrencyToken = Concurrency.CreateToken();
  }
}

namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent;

/// <summary>
/// Агрегат исходящего события приложения.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppOutgoingEventAggregate(
  AppOutgoingEventEntity? entityToChange,
  IAppOutgoingEventResources _resources,
  AppOutgoingEventEntitySettings _settings) : AggregateBase<AppOutgoingEventEntity, long>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppOutgoingEventEntity>> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      var isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.CreatedAt)) && inserted.CreatedAt != entity.CreatedAt)
      {
        inserted.CreatedAt = entity.CreatedAt;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.IsPublished)) && inserted.IsPublished != entity.IsPublished)
      {
        inserted.IsPublished = entity.IsPublished;

        isOk = true;
      }

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

    return new AggregateResult<EntityChange<AppOutgoingEventEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateCreatedAt(DateTimeOffset value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetCreatedAtIsInvalidErrorMessage();

      var appError = AppOutgoingEventErrorEnum.CreatedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.CreatedAt = value;

    MarkPropertyAsChanged(nameof(entity.CreatedAt));
  }

  /// <summary>
  /// Обновить дату создания.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateIsPublished(bool value)
  {
    var entity = GetEntityToUpdate();

    entity.IsPublished = value;

    MarkPropertyAsChanged(nameof(entity.IsPublished));
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

      var appError = AppOutgoingEventErrorEnum.NameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForName > 0 && value.Length > _settings.MaxLengthForName)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(_settings.MaxLengthForName);

      var appError = AppOutgoingEventErrorEnum.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Name = value;

    MarkPropertyAsChanged(nameof(entity.Name));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppOutgoingEventEntity entity)
  {
    RefreshConcurrencyToken(entity);

    entity.CreatedAt = DateTimeOffset.Now;
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppOutgoingEventEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(AppOutgoingEventEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid();
  }
}

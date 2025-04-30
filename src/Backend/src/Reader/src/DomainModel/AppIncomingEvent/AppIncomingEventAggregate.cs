namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent;

/// <summary>
/// Агрегат входящего события приложения.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppIncomingEventAggregate(
  AppIncomingEventEntity? entityToChange,
  IAppIncomingEventResources _resources,
  AppIncomingEventEntitySettings _settings) : AggregateBase<AppIncomingEventEntity, long>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppIncomingEventEntity>> GetResultToUpdate()
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

      if (HasChangedProperty(nameof(entity.LoadedAt)) && inserted.LoadedAt != entity.LoadedAt)
      {
        inserted.LoadedAt = entity.LoadedAt;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.Name)) && inserted.Name != entity.Name)
      {
        inserted.Name = entity.Name;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.CreatedAt)) && inserted.CreatedAt != entity.CreatedAt)
      {
        inserted.CreatedAt = entity.CreatedAt;

        isOk = true;
      }

      if (isOk)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppIncomingEventEntity>>(new(null, null));
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

      var appError = AppIncomingEventErrorEnum.CreatedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.CreatedAt = value;

    MarkPropertyAsChanged(nameof(entity.CreatedAt));
  }

  /// <summary>
  /// Обновить дату загрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateLoadedAt(DateTimeOffset? value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetLoadedAtIsInvalidErrorMessage();

      var appError = AppIncomingEventErrorEnum.LoadedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.LoadedAt = value;

    MarkPropertyAsChanged(nameof(entity.LoadedAt));
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

      var appError = AppIncomingEventErrorEnum.NameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventErrorEnum.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Name = value;

    MarkPropertyAsChanged(nameof(entity.Name));
  }

  /// <summary>
  /// Обновить дату обработки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateProcessedAt(DateTimeOffset? value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetProcessedAtIsInvalidErrorMessage();

      var appError = AppIncomingEventErrorEnum.ProcessedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.ProcessedAt = value;

    MarkPropertyAsChanged(nameof(entity.ProcessedAt));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppIncomingEventEntity entity)
  {
    RefreshConcurrencyToken(entity);

    entity.CreatedAt = DateTimeOffset.Now;
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppIncomingEventEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(AppIncomingEventEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid().ToString();
  }
}

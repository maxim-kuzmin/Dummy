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
  AppIncomingEventEntitySettings _settings) : AggregateBase<AppIncomingEventEntity, string>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<AppIncomingEventEntity> GetResultToUpdate()
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

      bool isCreatedAtPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.CreatedAt),
        () => target.CreatedAt != source.CreatedAt,
        () => target.CreatedAt = source.CreatedAt);

      bool isLoadedAtPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.LoadedAt),
        () => target.LoadedAt != source.LoadedAt,
        () => target.LoadedAt = source.LoadedAt);

      bool isEventIdPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.EventId),
        () => target.EventId != source.EventId,
        () => target.EventId = source.EventId);

      bool isEventNamePropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.EventName),
        () => target.EventName != source.EventName,
        () => target.EventName = source.EventName);

      bool isEntityChanged = isCreatedAtPropertyChanged
        ||
        isLoadedAtPropertyChanged
        ||
        isEventIdPropertyChanged
        ||
        isEventNamePropertyChanged;

      if (isEntityChanged)
      {
        return result;
      }
    }

    return AggregateResult<AppIncomingEventEntity>.CreateDefault();
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

    AddChangedProperty(nameof(entity.CreatedAt), entity.CreatedAt.ToString("O"));
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

    AddChangedProperty(nameof(entity.LoadedAt), entity.LoadedAt?.ToString("O"));
  }

  /// <summary>
  /// Обновить идентификатор события.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEventId(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetEventIdIsEmptyErrorMessage();

      var appError = AppIncomingEventErrorEnum.EventIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEventId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEventIdIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventErrorEnum.EventIdIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EventId = value;

    AddChangedProperty(nameof(entity.EventId), entity.EventId);
  }

  /// <summary>
  /// Обновить имя события.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEventName(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetEventNameIsEmptyErrorMessage();

      var appError = AppIncomingEventErrorEnum.EventNameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEventName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEventNameIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventErrorEnum.EventNameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EventName = value;

    AddChangedProperty(nameof(entity.EventName), entity.EventName);
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

    AddChangedProperty(nameof(entity.ProcessedAt), entity.ProcessedAt?.ToString("O"));
  }

  /// <inheritdoc/>
  protected sealed override string GetEntityName()
  {
    return "AppIncomingEvent";
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

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

      bool isEntityChanged =
        PrepareChangedPropertyToUpdate(
          nameof(source.CreatedAt),
          () => target.CreatedAt != source.CreatedAt,
          () => target.CreatedAt = source.CreatedAt)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.EventId),
          () => target.EventId != source.EventId,
          () => target.EventId = source.EventId)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.EventName),
          () => target.EventName != source.EventName,
          () => target.EventName = source.EventName)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.LastLoadingAt),
          () => target.LastLoadingAt != source.LastLoadingAt,
          () => target.LastLoadingAt = source.LastLoadingAt)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.LastLoadingError),
          () => target.LastLoadingError != source.LastLoadingError,
          () => target.LastLoadingError = source.LastLoadingError)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.LoadedAt),
          () => target.LoadedAt != source.LoadedAt,
          () => target.LoadedAt = source.LoadedAt)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.PayloadCount),
          () => target.PayloadCount != source.PayloadCount,
          () => target.PayloadCount = source.PayloadCount)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.PayloadTotalCount),
          () => target.PayloadTotalCount != source.PayloadTotalCount,
          () => target.PayloadTotalCount = source.PayloadTotalCount)
        ||
        PrepareChangedPropertyToUpdate(
          nameof(source.ProcessedAt),
          () => target.ProcessedAt != source.ProcessedAt,
          () => target.ProcessedAt = source.ProcessedAt);

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
  /// Обновить последнюю дату загрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateLastLoadingAt(DateTimeOffset? value)
  {
    if (value == default(DateTimeOffset))
    {
      string errorMessage = _resources.GetLastLoadingAtIsInvalidErrorMessage();

      var appError = AppIncomingEventErrorEnum.LastLoadingAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.LastLoadingAt = value;

    AddChangedProperty(nameof(entity.LastLoadingAt), entity.LastLoadingAt?.ToString("O"));
  }

  /// <summary>
  /// Обновить последнюю ошибку загрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateLastLoadingError(string? value)
  {
    int maxLength = _settings.MaxLengthForLastLoadingError;

    if (maxLength > 0 && value?.Length > maxLength)
    {
      string errorMessage = _resources.GetLastLoadingErrorIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventErrorEnum.LastLoadingErrorIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.LastLoadingError = value;

    AddChangedProperty(nameof(entity.LastLoadingError), entity.LastLoadingError);
  }

  /// <summary>
  /// Обновить дату загрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateLoadedAt(DateTimeOffset? value)
  {
    if (value == default(DateTimeOffset))
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
  /// Обновить количество полезной нагрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdatePayloadCount(int value)
  {
    if (value < 0)
    {
      string errorMessage = _resources.GetPayloadCountIsNegativeErrorMessage();

      var appError = AppIncomingEventErrorEnum.PayloadCountIsNegative.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.PayloadCount = value;

    AddChangedProperty(nameof(entity.PayloadCount), entity.PayloadCount.ToString());
  }

  /// <summary>
  /// Обновить количество полезной нагрузки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdatePayloadTotalCount(int value)
  {
    if (value < 0)
    {
      string errorMessage = _resources.GetPayloadTotalCountIsNegativeErrorMessage();

      var appError = AppIncomingEventErrorEnum.PayloadTotalCountIsNegative.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.PayloadTotalCount = value;

    AddChangedProperty(nameof(entity.PayloadTotalCount), entity.PayloadTotalCount.ToString());
  }

  /// <summary>
  /// Обновить дату обработки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateProcessedAt(DateTimeOffset? value)
  {
    if (value == default(DateTimeOffset))
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

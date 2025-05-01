namespace Makc.Dummy.Reader.DomainModel.AppIncomingEventPayload;

/// <summary>
/// Агрегат полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppIncomingEventPayloadAggregate(
  AppIncomingEventPayloadEntity? entityToChange,
  IAppIncomingEventPayloadResources _resources,
  AppIncomingEventPayloadEntitySettings _settings) : AggregateBase<AppIncomingEventPayloadEntity, string>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppIncomingEventPayloadEntity>> GetResultToUpdate()
  {
    var result = base.GetResultToUpdate();

    if (IsInvalidToUpdate(result))
    {
      return result;
    }

    if (HasChangedProperties())
    {
      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      bool isAppIncomingEventObjectIdChanged = HasChangedProperty(nameof(entity.AppIncomingEventObjectId))
        &&
        inserted.AppIncomingEventObjectId != entity.AppIncomingEventObjectId;

      if (isAppIncomingEventObjectIdChanged)
      {
        inserted.AppIncomingEventObjectId = entity.AppIncomingEventObjectId;
      }

      bool isDataChanged = HasChangedProperty(nameof(entity.Data)) && inserted.Data != entity.Data;

      if (isDataChanged)
      {
        inserted.Data = entity.Data;
      }

      bool isChanged = isAppIncomingEventObjectIdChanged || isDataChanged;

      if (isChanged)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppIncomingEventPayloadEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить идентификатор входящего события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppIncomingEventId(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetAppIncomingEventIdIsEmptyErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.AppIncomingEventIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForAppIncomingEventId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetAppIncomingEventIdIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.AppIncomingEventIdIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.AppIncomingEventObjectId = value;

    MarkPropertyAsChanged(nameof(entity.AppIncomingEventObjectId));
  }

  /// <summary>
  /// Обновить токен параллелизма сущности для удаления.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityConcurrencyTokenToDelete(string? value)
  {
    int maxLength = _settings.MaxLengthForConcurrencyToken;

    if (value != null && maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityConcurrencyTokenToDeleteIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.EntityConcurrencyTokenToDeleteIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToDelete = value;

    MarkPropertyAsChanged(nameof(entity.EntityConcurrencyTokenToDelete));
  }

  /// <summary>
  /// Обновить токен параллелизма для вставки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityConcurrencyTokenToInsert(string? value)
  {
    int maxLength = _settings.MaxLengthForConcurrencyToken;

    if (value != null && maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityConcurrencyTokenToInsertIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.EntityConcurrencyTokenToInsertIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToInsert = value;

    MarkPropertyAsChanged(nameof(entity.EntityConcurrencyTokenToInsert));
  }

  /// <summary>
  /// Обновить данные.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateData(string? value)
  {
    int maxLength = _settings.MaxLengthForData;

    if (value != null && maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetDataIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.DataIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Data = value;

    MarkPropertyAsChanged(nameof(entity.Data));
  }

  /// <summary>
  /// Обновить идентификатор сущности.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityId(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetEntityIdIsEmptyErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.EntityIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEntityId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityIdIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.EntityIdTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityId = value;

    MarkPropertyAsChanged(nameof(entity.EntityId));
  }

  /// <summary>
  /// Обновить имя сущности.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityName(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetEntityNameIsEmptyErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.EntityNameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEntityName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityNameIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.EntityNameTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityName = value;

    MarkPropertyAsChanged(nameof(entity.EntityName));
  }

  /// <summary>
  /// Обновить идентификатор полезной нагрузки события.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEventPayloadId(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetEventPayloadIdIsEmptyErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.EventPayloadIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEventPayloadId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEventPayloadIdIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.EventPayloadIdTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EventPayloadId = value;

    MarkPropertyAsChanged(nameof(entity.EventPayloadId));
  }

  /// <summary>
  /// Обновить позицию.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdatePosition(int value)
  {
    if (value < 1)
    {
      string errorMessage = _resources.GetPositionIsNotPositiveNumberErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.PositionIsNotPositiveNumber.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Position = value;

    MarkPropertyAsChanged(nameof(entity.Position));
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppIncomingEventPayloadEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }
  
  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppIncomingEventPayloadEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(AppIncomingEventPayloadEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid().ToString();
  }
}

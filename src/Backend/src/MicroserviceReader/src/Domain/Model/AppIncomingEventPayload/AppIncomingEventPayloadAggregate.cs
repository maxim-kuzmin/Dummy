namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEventPayload;

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
  public sealed override AggregateResult<AppIncomingEventPayloadEntity> GetResultToUpdate()
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

      bool[] updates = [
        PrepareChangedPropertyToUpdate(
          nameof(source.AppIncomingEventObjectId),
          () => target.AppIncomingEventObjectId != source.AppIncomingEventObjectId,
          () => target.AppIncomingEventObjectId = source.AppIncomingEventObjectId),
        PrepareChangedPropertyToUpdate(
          nameof(source.CreatedAt),
          () => target.CreatedAt != source.CreatedAt,
          () => target.CreatedAt = source.CreatedAt),
        PrepareChangedPropertyToUpdate(
          nameof(source.Data),
          () => target.Data != source.Data,
          () => target.Data = source.Data),
        PrepareChangedPropertyToUpdate(
          nameof(source.EntityConcurrencyTokenToDelete),
          () => target.EntityConcurrencyTokenToDelete != source.EntityConcurrencyTokenToDelete,
          () => target.EntityConcurrencyTokenToDelete = source.EntityConcurrencyTokenToDelete),
        PrepareChangedPropertyToUpdate(
          nameof(source.EntityConcurrencyTokenToInsert),
          () => target.EntityConcurrencyTokenToInsert != source.EntityConcurrencyTokenToInsert,
          () => target.EntityConcurrencyTokenToInsert = source.EntityConcurrencyTokenToInsert),
        PrepareChangedPropertyToUpdate(
          nameof(source.EntityId),
          () => target.EntityId != source.EntityId,
          () => target.EntityId = source.EntityId),
        PrepareChangedPropertyToUpdate(
          nameof(source.EntityName),
          () => target.EntityName != source.EntityName,
          () => target.EntityName = source.EntityName),
        PrepareChangedPropertyToUpdate(
          nameof(source.EventPayloadId),
          () => target.EventPayloadId != source.EventPayloadId,
          () => target.EventPayloadId = source.EventPayloadId),
        PrepareChangedPropertyToUpdate(
          nameof(source.Position),
          () => target.Position != source.Position,
          () => target.Position = source.Position)
        ];

      if (updates.Any(x => x == true))
      {
        return result;
      }
    }

    return AggregateResult<AppIncomingEventPayloadEntity>.CreateDefault();
  }

  /// <summary>
  /// Обновить идентификатор входящего события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppIncomingEventObjectId(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetAppIncomingEventObjectIdIsEmptyErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.AppIncomingEventIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForAppIncomingEventId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetAppIncomingEventObjectIdIsTooLongErrorMessage(maxLength);

      var appError = AppIncomingEventPayloadErrorEnum.AppIncomingEventIdIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.AppIncomingEventObjectId = value;

    AddChangedProperty(nameof(entity.AppIncomingEventObjectId), entity.AppIncomingEventObjectId);
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

      var appError = AppIncomingEventPayloadErrorEnum.CreatedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.CreatedAt = value;

    AddChangedProperty(nameof(entity.CreatedAt), entity.CreatedAt.ToString("O"));
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

    AddChangedProperty(nameof(entity.Data), entity.Data);
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

    AddChangedProperty(nameof(entity.EntityConcurrencyTokenToDelete), entity.EntityConcurrencyTokenToDelete);
  }

  /// <summary>
  /// Обновить токен параллелизма сущности для вставки.
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

    AddChangedProperty(nameof(entity.EntityConcurrencyTokenToInsert), entity.EntityConcurrencyTokenToInsert);
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

    AddChangedProperty(nameof(entity.EntityId), entity.EntityId);
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

    AddChangedProperty(nameof(entity.EntityName), entity.EntityName);
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

    AddChangedProperty(nameof(entity.EventPayloadId), entity.EventPayloadId);
  }

  /// <summary>
  /// Обновить позицию.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdatePosition(int value)
  {
    if (value < 1)
    {
      string errorMessage = _resources.GetPositionIsNegativeErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.PositionIsNegative.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Position = value;

    AddChangedProperty(nameof(entity.Position), entity.Position.ToString());
  }

  /// <inheritdoc/>
  protected sealed override string GetEntityName()
  {
    return "AppIncomingEventPayload";
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppIncomingEventPayloadEntity entity)
  {
    RefreshConcurrencyToken(entity);

    entity.CreatedAt = DateTimeOffset.Now;
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

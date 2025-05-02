namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Агрегат полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="entityToChange">Сущность для изменения.</param>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppOutgoingEventPayloadAggregate(
  AppOutgoingEventPayloadEntity? entityToChange,
  IAppOutgoingEventPayloadResources _resources,
  AppOutgoingEventPayloadEntitySettings _settings) : AggregateBase<AppOutgoingEventPayloadEntity, long>(entityToChange)
{
  /// <inheritdoc/>
  public sealed override AggregateResult<EntityChange<AppOutgoingEventPayloadEntity>> GetResultToUpdate()
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

      bool isAppOutgoingEventIdPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(entity.AppOutgoingEventId),
        () => inserted.AppOutgoingEventId != entity.AppOutgoingEventId,
        () => inserted.AppOutgoingEventId = entity.AppOutgoingEventId);

      bool isDataPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(entity.Data),
        () => inserted.Data != entity.Data,
        () => inserted.Data = entity.Data);

      bool isEntityChanged = isAppOutgoingEventIdPropertyChanged || isDataPropertyChanged;

      if (isEntityChanged)
      {
        return result;
      }
    }

    return new AggregateResult<EntityChange<AppOutgoingEventPayloadEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить идентификатор исходящего события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppOutgoingEventId(long value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetAppOutgoingEventIdIsInvalidErrorMessage();

      var appError = AppOutgoingEventPayloadErrorEnum.AppOutgoingEventIdIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.AppOutgoingEventId = value;

    AddChangedProperty(nameof(entity.AppOutgoingEventId), entity.AppOutgoingEventId.ToString());
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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityConcurrencyTokenToDeleteIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToDelete = value;

    AddChangedProperty(nameof(entity.EntityConcurrencyTokenToDelete), entity.EntityConcurrencyTokenToDelete);
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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityConcurrencyTokenToInsertIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToInsert = value;

    AddChangedProperty(nameof(entity.EntityConcurrencyTokenToInsert), entity.EntityConcurrencyTokenToInsert);
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

      var appError = AppOutgoingEventPayloadErrorEnum.DataIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Data = value;

    AddChangedProperty(nameof(entity.Data), entity.Data);
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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEntityId;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityIdIsTooLongErrorMessage(maxLength);

      var appError = AppOutgoingEventPayloadErrorEnum.EntityIdTooLong.ToAppError(errorMessage);

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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityNameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    int maxLength = _settings.MaxLengthForEntityName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetEntityNameIsTooLongErrorMessage(maxLength);

      var appError = AppOutgoingEventPayloadErrorEnum.EntityNameTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityName = value;

    AddChangedProperty(nameof(entity.EntityName), entity.EntityName);
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

      var appError = AppOutgoingEventPayloadErrorEnum.PositionIsNotPositiveNumber.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Position = value;

    AddChangedProperty(nameof(entity.Position), entity.Position.ToString());
  }

  /// <inheritdoc/>
  protected sealed override string GetEntityName()
  {
    return "AppOutgoingEventPayload";
  }

  /// <inheritdoc/>
  protected sealed override void OnGetResultToCreate(AppOutgoingEventPayloadEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }
  
  /// <inheritdoc/>
  protected sealed override void OnGetResultToUpdate(AppOutgoingEventPayloadEntity entity)
  {
    RefreshConcurrencyToken(entity);
  }

  private static void RefreshConcurrencyToken(AppOutgoingEventPayloadEntity entity)
  {
    entity.ConcurrencyToken = Guid.NewGuid().ToString();
  }
}

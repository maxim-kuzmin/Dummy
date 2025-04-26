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
      bool isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.AppOutgoingEventId)) && inserted.AppOutgoingEventId != entity.AppOutgoingEventId)
      {
        inserted.AppOutgoingEventId = entity.AppOutgoingEventId;

        isOk = true;
      }

      if (HasChangedProperty(nameof(entity.Data)) && inserted.Data != entity.Data)
      {
        inserted.Data = entity.Data;

        isOk = true;
      }

      if (isOk)
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

    MarkPropertyAsChanged(nameof(entity.AppOutgoingEventId));
  }

  /// <summary>
  /// Обновить токен параллелизма сущности для удаления.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityConcurrencyTokenToDelete(Guid? value)
  {
    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToDelete = value;

    MarkPropertyAsChanged(nameof(entity.EntityConcurrencyTokenToDelete));
  }

  /// <summary>
  /// Обновить токен параллелизма для вставки.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateEntityConcurrencyTokenToInsert(Guid? value)
  {
    var entity = GetEntityToUpdate();

    entity.EntityConcurrencyTokenToInsert = value;

    MarkPropertyAsChanged(nameof(entity.EntityConcurrencyTokenToInsert));
  }

  /// <summary>
  /// Обновить данные.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateData(string value) // //makc//DEL//
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      string errorMessage = _resources.GetDataIsEmptyErrorMessage();

      var appError = AppOutgoingEventPayloadErrorEnum.DataIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForData > 0 && value.Length > _settings.MaxLengthForData)
    {
      string errorMessage = _resources.GetDataIsTooLongErrorMessage(_settings.MaxLengthForData);

      var appError = AppOutgoingEventPayloadErrorEnum.DataIsTooLong.ToAppError(errorMessage);

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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityIdIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForEntityId > 0 && value.Length > _settings.MaxLengthForEntityId)
    {
      string errorMessage = _resources.GetEntityIdIsTooLongErrorMessage(_settings.MaxLengthForEntityId);

      var appError = AppOutgoingEventPayloadErrorEnum.EntityIdTooLong.ToAppError(errorMessage);

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

      var appError = AppOutgoingEventPayloadErrorEnum.EntityNameIsEmpty.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    if (_settings.MaxLengthForEntityName > 0 && value.Length > _settings.MaxLengthForEntityName)
    {
      string errorMessage = _resources.GetEntityNameIsTooLongErrorMessage(_settings.MaxLengthForEntityName);

      var appError = AppOutgoingEventPayloadErrorEnum.EntityNameTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.EntityName = value;

    MarkPropertyAsChanged(nameof(entity.EntityName));
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

    MarkPropertyAsChanged(nameof(entity.Position));
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
    entity.ConcurrencyToken = Guid.NewGuid();
  }
}

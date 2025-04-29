using Makc.Dummy.Reader.DomainModel.AppIncomingEventPayload.Entity;

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
  AppIncomingEventPayloadEntitySettings _settings) : AggregateBase<AppIncomingEventPayloadEntity, long>(entityToChange)
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
      bool isOk = false;

      var inserted = result.Data!.Inserted!;

      var entity = GetEntityToUpdate();

      if (HasChangedProperty(nameof(entity.AppIncomingEventId)) && inserted.AppIncomingEventId != entity.AppIncomingEventId)
      {
        inserted.AppIncomingEventId = entity.AppIncomingEventId;

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

    return new AggregateResult<EntityChange<AppIncomingEventPayloadEntity>>(new(null, null));
  }

  /// <summary>
  /// Обновить идентификатор входящего события приложения.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdateAppIncomingEventId(long value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetAppIncomingEventIdIsInvalidErrorMessage();

      var appError = AppIncomingEventPayloadErrorEnum.AppIncomingEventIdIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.AppIncomingEventId = value;

    MarkPropertyAsChanged(nameof(entity.AppIncomingEventId));
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

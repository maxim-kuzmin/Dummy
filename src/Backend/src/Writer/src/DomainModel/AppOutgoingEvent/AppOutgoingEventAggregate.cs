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
  public sealed override AggregateResult<AppOutgoingEventEntity> GetResultToUpdate()
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

      bool isNamePropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.Name),
        () => target.Name != source.Name,
        () => target.Name = source.Name);

      bool isPublishedAtPropertyChanged = PrepareChangedPropertyToUpdate(
        nameof(source.PublishedAt),
        () => target.PublishedAt != source.PublishedAt,
        () => target.PublishedAt = source.PublishedAt);

      bool isEntityChanged = isCreatedAtPropertyChanged || isNamePropertyChanged || isPublishedAtPropertyChanged;

      if (isEntityChanged)
      {
        return result;
      }
    }

    return AggregateResult<AppOutgoingEventEntity>.CreateDefault();
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

    AddChangedProperty(nameof(entity.CreatedAt), entity.CreatedAt.ToString("O"));
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

    int maxLength = _settings.MaxLengthForName;

    if (maxLength > 0 && value.Length > maxLength)
    {
      string errorMessage = _resources.GetNameIsTooLongErrorMessage(maxLength);

      var appError = AppOutgoingEventErrorEnum.NameIsTooLong.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.Name = value;

    AddChangedProperty(nameof(entity.Name), entity.Name);
  }

  /// <summary>
  /// Обновить дату публикации.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void UpdatePublishedAt(DateTimeOffset? value)
  {
    if (value == default)
    {
      string errorMessage = _resources.GetPublishedAtIsInvalidErrorMessage();

      var appError = AppOutgoingEventErrorEnum.PublishedAtIsInvalid.ToAppError(errorMessage);

      UpdateErrors.Add(appError);
    }

    var entity = GetEntityToUpdate();

    entity.PublishedAt = value;

    AddChangedProperty(nameof(entity.PublishedAt), entity.PublishedAt?.ToString("O"));
  }

  /// <inheritdoc/>
  protected sealed override string GetEntityName()
  {
    return "AppOutgoingEvent";
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
    entity.ConcurrencyToken = Guid.NewGuid().ToString();
  }
}

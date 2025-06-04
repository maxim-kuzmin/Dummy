namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.Core.AppIncomingEventPayload;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppIncomingEventPayloadResources(
  IStringLocalizer<AppIncomingEventPayloadResources> _stringLocalizer) : IAppIncomingEventPayloadResources
{
  /// <inheritdoc/>
  public string GetAppIncomingEventObjectIdIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:AppIncomingEventObjectIdIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetAppIncomingEventObjectIdIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:AppIncomingEventObjectIdIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetCreatedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:CreatedAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetDataIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:DataIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEntityConcurrencyTokenToDeleteIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EntityConcurrencyTokenToDeleteIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEntityConcurrencyTokenToInsertIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EntityConcurrencyTokenToInsertIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEntityIdIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:EntityIdIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetEntityIdIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EntityIdIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEntityNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:EntityNameIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetEntityNameIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EntityNameIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEventPayloadIdIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:EventPayloadIdIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetEventPayloadIdIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EventPayloadIdIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetPositionIsNegativeErrorMessage()
  {
    return _stringLocalizer["Error:PositionIsNegative"];
  }
}

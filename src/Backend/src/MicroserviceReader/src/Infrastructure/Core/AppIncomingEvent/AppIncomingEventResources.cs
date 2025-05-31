namespace Makc.Dummy.MicroserviceReader.Infrastructure.Core.AppIncomingEvent;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppIncomingEventResources(
  IStringLocalizer<AppIncomingEventResources> _stringLocalizer) : IAppIncomingEventResources
{
  /// <inheritdoc/>
  public string GetCreatedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:CreatedAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetEventIdIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:EventIdIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetEventIdIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EventIdIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetEventNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:EventNameIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetEventNameIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:EventNameIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetLastLoadingAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:LastLoadingAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetLastLoadingErrorIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:LastLoadingErrorIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetLastProcessingAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:LastProcessingAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetLastProcessingErrorIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:LastProcessingErrorIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetLoadedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:LoadedAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetPayloadCountIsNegativeErrorMessage()
  {
    return _stringLocalizer["Error:PayloadCountIsNegative"];
  }

  /// <inheritdoc/>
  public string GetPayloadTotalCountIsNegativeErrorMessage()
  {
    return _stringLocalizer["Error:PayloadTotalCountIsNegative"];
  }

  /// <inheritdoc/>
  public string GetProcessedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:ProcessedAtIsInvalid"];
  }
}

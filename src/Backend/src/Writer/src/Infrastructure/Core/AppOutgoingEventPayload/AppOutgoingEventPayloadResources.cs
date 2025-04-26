namespace Makc.Dummy.Writer.Infrastructure.Core.AppOutgoingEventPayload;

/// <summary>
/// Ресурсы полезной нагрузки исходящего сообщения приложения.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppOutgoingEventPayloadResources(IStringLocalizer<AppOutgoingEventPayloadResources> _stringLocalizer) : IAppOutgoingEventPayloadResources
{
  /// <inheritdoc/>
  public string GetAppOutgoingEventIdIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:EventIdIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetDataIsEmptyErrorMessage() // //makc//DEL//
  {
    return _stringLocalizer["Error:DataIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetDataIsTooLongErrorMessage(int maxLength) // //makc//DEL//
  {
    return _stringLocalizer["Error:DataIsTooLong:Format", maxLength];
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
  public string GetPositionIsNotPositiveNumberErrorMessage()
  {
    return _stringLocalizer["Error:PositionIsNotPositiveNumber"];
  }
}

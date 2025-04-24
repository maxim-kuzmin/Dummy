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
  public string GetDataIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:DataIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetDataIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:Format:DataIsTooLong", maxLength];
  }
}

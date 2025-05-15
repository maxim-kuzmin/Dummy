namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Core.AppOutgoingEvent;

/// <summary>
/// Ресурсы исходящего сообщения приложения.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppOutgoingEventResources(IStringLocalizer<AppOutgoingEventResources> _stringLocalizer) : IAppOutgoingEventResources
{
  /// <inheritdoc/>
  public string GetCreatedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:CreatedAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:NameIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetNameIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:NameIsTooLong:Format", maxLength];
  }

  /// <inheritdoc/>
  public string GetPublishedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:PublishedAtIsInvalid"];
  }
}

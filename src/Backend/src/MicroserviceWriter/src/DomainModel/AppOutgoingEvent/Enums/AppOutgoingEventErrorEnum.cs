namespace Makc.Dummy.MicroserviceWriter.DomainModel.AppOutgoingEvent.Enums;

/// <summary>
/// Перечисление ошибок исходящего события приложения.
/// </summary>
public enum AppOutgoingEventErrorEnum
{
  /// <summary>
  /// Дата создания недействительна.
  /// </summary>
  CreatedAtIsInvalid,

  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty,

  /// <summary>
  /// Имя слишком длинное.
  /// </summary>
  NameIsTooLong,

  /// <summary>
  /// Дата публикации недействительна.
  /// </summary>
  PublishedAtIsInvalid,
}

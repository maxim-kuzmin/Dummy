namespace Makc.Dummy.Shared.Domain.Model.Aggregate;

/// <summary>
/// Результат агрегата.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="Entity">Сущность.</param>
/// <param name="Payload">Полезная нагрузка.</param>
/// <param name="Errors">Ошибки.</param>
public record AggregateResult<TEntity>(
  TEntity? Entity,
  AppEventDictionaryPayload? Payload,
  HashSet<AppError>? Errors = null)
  where TEntity : class
{
  /// <summary>
  /// Создать по умолчанию.
  /// </summary>
  /// <returns>Результат агрегата по умолчанию.</returns>
  public static AggregateResult<TEntity> CreateDefault()
  {
    return new(null, null);
  }

  /// <summary>
  /// Недействителен ли?
  /// </summary>
  public bool IsInvalid => Entity == null || Errors?.Count > 0;

  /// <summary>
  /// Недействителен ли для обновления?
  /// </summary>
  /// <param name="aggregateResult">Результат агрегата.</param>
  /// <returns>Если недействителен для обновления, то true, иначе - false.</returns>
  public bool IsInvalidForUpdate =>  
      IsInvalid
      ||
      Payload?.EntityConcurrencyTokenToDelete == null
      ||
      Payload?.EntityConcurrencyTokenToInsert == null;  

  /// <summary>
  /// Преобразовать к ошибкам валидации.
  /// </summary>
  /// <param name="funcToGetIdentifierByCode">Функция для получения идентификатора по коду.</param>
  /// <param name="funcToGetSeverityByCode">Функция для получения серьёзности по коду.</param>
  /// <returns>Ошибки валидации.</returns>
  public List<ValidationError> ToValidationErrors(
    Func<string, string>? funcToGetIdentifierByCode = null,
    Func<string, ValidationSeverity>? funcToGetSeverityByCode = null)
  {
    if (Errors == null || Errors.Count == 0)
    {
      return [];
    }

    List<ValidationError> result = new(Errors.Count);

    foreach (var error in Errors)
    {
      var validationError = new ValidationError(
        funcToGetIdentifierByCode != null ? funcToGetIdentifierByCode.Invoke(error.Code) : string.Empty,
        error.Message,
        error.Code,
        funcToGetSeverityByCode != null ? funcToGetSeverityByCode.Invoke(error.Code): ValidationSeverity.Error);

      result.Add(validationError);
    }

    return result;
  }
}

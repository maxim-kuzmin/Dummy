namespace Makc.Dummy.Shared.Core.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Выбросить исключение RPC для неуспешного результата.
  /// </summary>
  /// <param name="result">Результат.</param>
  public static void ThrowExceptionIfNotSuccess(this Result result)
  {
    if (!result.IsSuccess)
    {
      result.ThrowException();
    }
  }

  /// <summary>
  /// Выбросить исключение RPC для неуспешного результата.
  /// </summary>
  /// <typeparam name="T">Тип значения результата.</typeparam>
  /// <param name="result">Результат.</param>
  public static void ThrowExceptionIfNotSuccess<T>(this Result<T> result)
  {
    if (!result.IsSuccess)
    {
      result.ThrowException();
    }
  }

  /// <summary>
  /// Преобразовать к ошибке приложения.
  /// </summary>
  /// <param name="error">Ошибка.</param>
  /// <param name="errorMessage">Сообщение об ошибке.</param>
  /// <returns>Ошибка приложения.</returns>
  public static AppError ToAppError<T>(this T error, string errorMessage) where T: Enum
  {
    return new(error.ToAppErrorCode(), errorMessage);
  }

  /// <summary>
  /// Преобразовать к коду ошибки приложения.
  /// </summary>
  /// <param name="error">Ошибка.</param>
  /// <returns>Код ошибки приложения.</returns>
  public static string ToAppErrorCode<T>(this T error) where T : Enum
  {
    return $"{typeof(T).Name}.{error}";
  }

  /// <summary>
  /// Преобразовать к подробному сообщению об ошибке.
  /// </summary>
  /// <param name="result">Результат.</param>
  /// <returns>Сообщение об ошибке.</returns>
  public static string ToDetailErrorMessage(this IResult result)
  {
    if (result.ValidationErrors.Any())
    {
      var stringBuilder = new StringBuilder("Validation error(s) occurred:");

      foreach (var error in result.ValidationErrors)
      {
        stringBuilder.Append("* ").Append(error.ToErrorMessage()).AppendLine();
      }

      return stringBuilder.ToString();
    }
    else if (result.Errors.Any())
    {
      var stringBuilder = new StringBuilder("Next error(s) occurred:");

      foreach (var error in result.Errors)
      {
        stringBuilder.Append("* ").Append(error).AppendLine();
      }

      return stringBuilder.ToString();
    }

    return string.Empty;
  }

  /// <summary>
  /// Преобразовать к основному сообщению об ошибке.
  /// </summary>
  /// <param name="result">Результат.</param>
  /// <returns>Сообщение об ошибке.</returns>
  public static string ToMainErrorMessage(this IResult result)
  {
    return result.Status switch
    {
      ResultStatus.Error => "Something went wrong",
      ResultStatus.Forbidden => "Forbidden",
      ResultStatus.Unauthorized => "Unauthorized",
      ResultStatus.Invalid => "Bad request",
      ResultStatus.NotFound => "Resource not found.",
      ResultStatus.Conflict => "There was a conflict",
      ResultStatus.CriticalError => "Something went wrong",
      ResultStatus.Unavailable => "Service unavailable",
      _ => "Something went wrong",
    };
  }

  private static void ThrowException(this IResult result)
  {
    List<string> parts = new(2)
    {
      result.ToMainErrorMessage()
    };

    string detail = result.ToDetailErrorMessage();

    if (!string.IsNullOrWhiteSpace(detail))
    {
      parts.Add(detail);
    }

    throw new Exception(string.Join(" .", parts));
  }

  private static string ToErrorMessage(this ValidationError validationError)
  {
    List<string> parts = new(4)
    {
      $"Severity: {validationError.Severity}"
    };

    if (!string.IsNullOrWhiteSpace(validationError.Identifier))
    {
      parts.Add($"Identifier: {validationError.Identifier}");
    }

    if (!string.IsNullOrWhiteSpace(validationError.ErrorCode))
    {
      parts.Add($"ErrorCode: {validationError.ErrorCode}");
    }

    if (!string.IsNullOrWhiteSpace(validationError.ErrorMessage))
    {
      parts.Add($"ErrorMessage: {validationError.ErrorMessage}");
    }

    return string.Join(", ", parts);
  }
}

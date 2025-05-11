namespace Makc.Dummy.Shared.Infrastructure.Grpc;

/// <summary>
/// Расширения.
/// </summary>
public static class Extensions
{
  /// <summary>
  /// Добавить заголовок авторизации.
  /// </summary>
  /// <param name="headers">Заголовки.</param>
  /// <param name="appSession">Сессия приложения.</param>
  /// <returns>Заголовки.</returns>
  public static Metadata AddAuthorizationHeader(this Metadata headers, AppSession appSession)
  {
    var accessToken = appSession.AccessToken;

    if (!string.IsNullOrWhiteSpace(accessToken))
    {
      headers.Add("Authorization", $"Bearer {accessToken}");
    }

    return headers;
  }

  /// <summary>
  /// Выбросить исключение RPC для неуспешного результата.
  /// </summary>
  /// <param name="result">Результат.</param>
  public static void ThrowRpcExceptionIfNotSuccess(this Result result)
  {
    if (!result.IsSuccess)
    {
      result.ThrowRpcException();
    }
  }

  /// <summary>
  /// Выбросить исключение RPC для неуспешного результата.
  /// </summary>
  /// <typeparam name="T">Тип значения результата.</typeparam>
  /// <param name="result">Результат.</param>
  public static void ThrowRpcExceptionIfNotSuccess<T>(this Result<T> result)
  {
    if (!result.IsSuccess)
    {
      result.ThrowRpcException();
    }
  }

  /// <summary>
  /// Преобразовать к коду gRPC-статуса.
  /// </summary>
  /// <param name="httpStatusCode">Код HTTP-статуса.</param>
  /// <returns>gRPC-статус.</returns>
  public static StatusCode? ToGrpcStatusCode(this HttpStatusCode httpStatusCode)
  {
    switch (httpStatusCode)
    {
      case HttpStatusCode.Continue:
      case HttpStatusCode.SwitchingProtocols:
      case HttpStatusCode.Processing:
      case HttpStatusCode.EarlyHints:
      case HttpStatusCode.OK:
      case HttpStatusCode.Created:
      case HttpStatusCode.Accepted:
      case HttpStatusCode.NonAuthoritativeInformation:
      case HttpStatusCode.NoContent:
      case HttpStatusCode.ResetContent:
      case HttpStatusCode.PartialContent:
      case HttpStatusCode.MultiStatus:
      case HttpStatusCode.AlreadyReported:
      case HttpStatusCode.IMUsed:
        return StatusCode.OK;
      case HttpStatusCode.Ambiguous:
      case HttpStatusCode.Moved:
      case HttpStatusCode.Found:
      case HttpStatusCode.RedirectMethod:
      case HttpStatusCode.NotModified:
      case HttpStatusCode.UseProxy:
      case HttpStatusCode.Unused:
      case HttpStatusCode.RedirectKeepVerb:
      case HttpStatusCode.PermanentRedirect:
        break;
      case HttpStatusCode.BadRequest:
        return StatusCode.InvalidArgument;
      case HttpStatusCode.Unauthorized:
        return StatusCode.Unauthenticated;
      case HttpStatusCode.PaymentRequired:
        break;
      case HttpStatusCode.Forbidden:
        return StatusCode.PermissionDenied;
      case HttpStatusCode.NotFound:
        return StatusCode.NotFound;
      case HttpStatusCode.MethodNotAllowed:
      case HttpStatusCode.NotAcceptable:
      case HttpStatusCode.ProxyAuthenticationRequired:
        break;
      case HttpStatusCode.RequestTimeout: // Должно быть 499 Client Closed Request, но такаго варианта нет в перечислении HttpStatusCode
        return StatusCode.Cancelled;
      case HttpStatusCode.Conflict:
        return StatusCode.Aborted;
      case HttpStatusCode.Gone:
      case HttpStatusCode.LengthRequired:
      case HttpStatusCode.PreconditionFailed:
      case HttpStatusCode.RequestEntityTooLarge:
      case HttpStatusCode.RequestUriTooLong:
      case HttpStatusCode.UnsupportedMediaType:
      case HttpStatusCode.RequestedRangeNotSatisfiable:
      case HttpStatusCode.ExpectationFailed:
      case HttpStatusCode.MisdirectedRequest:
      case HttpStatusCode.UnprocessableEntity:
      case HttpStatusCode.Locked:
      case HttpStatusCode.FailedDependency:
      case HttpStatusCode.UpgradeRequired:
      case HttpStatusCode.PreconditionRequired:
        break;
      case HttpStatusCode.TooManyRequests:
        return StatusCode.ResourceExhausted;
      case HttpStatusCode.RequestHeaderFieldsTooLarge:
      case HttpStatusCode.UnavailableForLegalReasons:
        break;
      case HttpStatusCode.InternalServerError:
        return StatusCode.Unknown;
      case HttpStatusCode.NotImplemented:
        return StatusCode.Unimplemented;
      case HttpStatusCode.BadGateway:
        break;
      case HttpStatusCode.ServiceUnavailable:
        return StatusCode.Unavailable;
      case HttpStatusCode.GatewayTimeout:
        return StatusCode.DeadlineExceeded;
      case HttpStatusCode.HttpVersionNotSupported:
      case HttpStatusCode.VariantAlsoNegotiates:
      case HttpStatusCode.InsufficientStorage:
      case HttpStatusCode.LoopDetected:
      case HttpStatusCode.NotExtended:
      case HttpStatusCode.NetworkAuthenticationRequired:
        break;
    }

    return null;
  }

  /// <summary>
  /// Преобразовать к коду HTTP-статуса.
  /// </summary>
  /// <param name="grpcStatusCode">Код gRPC-статуса.</param>
  /// <returns></returns>
  public static HttpStatusCode? ToHttpStatusCode(this StatusCode grpcStatusCode)
  {
    return grpcStatusCode switch
    {
      StatusCode.OK => (HttpStatusCode?)HttpStatusCode.OK,
      StatusCode.Cancelled => (HttpStatusCode?)HttpStatusCode.RequestTimeout,// Должно быть 499 Client Closed Request, но такаго варианта нет в перечислении HttpStatusCode
      StatusCode.Unknown => (HttpStatusCode?)HttpStatusCode.InternalServerError,
      StatusCode.InvalidArgument => (HttpStatusCode?)HttpStatusCode.BadRequest,
      StatusCode.DeadlineExceeded => (HttpStatusCode?)HttpStatusCode.GatewayTimeout,
      StatusCode.NotFound => (HttpStatusCode?)HttpStatusCode.NotFound,
      StatusCode.AlreadyExists => (HttpStatusCode?)HttpStatusCode.Conflict,
      StatusCode.PermissionDenied => (HttpStatusCode?)HttpStatusCode.Forbidden,
      StatusCode.Unauthenticated => (HttpStatusCode?)HttpStatusCode.Unauthorized,
      StatusCode.ResourceExhausted => (HttpStatusCode?)HttpStatusCode.TooManyRequests,
      StatusCode.FailedPrecondition => (HttpStatusCode?)HttpStatusCode.BadRequest,
      StatusCode.Aborted => (HttpStatusCode?)HttpStatusCode.Conflict,
      StatusCode.OutOfRange => (HttpStatusCode?)HttpStatusCode.BadRequest,
      StatusCode.Unimplemented => (HttpStatusCode?)HttpStatusCode.NotImplemented,
      StatusCode.Internal => (HttpStatusCode?)HttpStatusCode.InternalServerError,
      StatusCode.Unavailable => (HttpStatusCode?)HttpStatusCode.ServiceUnavailable,
      StatusCode.DataLoss => (HttpStatusCode?)HttpStatusCode.InternalServerError,
      _ => null,
    };
  }

  /// <summary>
  /// Преобразовать к неуспешному результату.
  /// </summary>
  /// <param name="ex">Исключение RPC.</param>
  /// <returns>Результат.</returns>
  public static Result ToUnsuccessfulResult(this RpcException ex)
  {
    return ex.StatusCode switch
    {
      StatusCode.Aborted or StatusCode.AlreadyExists => Result.Conflict(),
      StatusCode.PermissionDenied => Result.Forbidden(),
      StatusCode.NotFound => Result.NotFound(),
      StatusCode.DataLoss => Result.Unavailable(),
      StatusCode.Unauthenticated => Result.Unauthorized(),
      StatusCode.InvalidArgument or StatusCode.OutOfRange or StatusCode.FailedPrecondition => Result.Invalid(new ValidationError(ex.Message)),
      StatusCode.Unknown => Result.Error(ex.Message),
      _ => Result.CriticalError(ex.Message),
    };
  }

  private static void ThrowRpcException(this IResult result)
  {
    var message = result.ToMainErrorMessage();

    var detail = result.ToDetailErrorMessage();

    StatusCode statusCode = result.Status.ToRpcStatusCode();

    Exception? debugException = statusCode != StatusCode.Unknown
      ? null
      : new NotSupportedException($"Result {result.Status} conversion is not supported.");

    throw new RpcException(new Status(statusCode, detail, debugException), message);
  }

  private static StatusCode ToRpcStatusCode(this ResultStatus status)
  {
    return status switch
    {
      ResultStatus.Error => StatusCode.InvalidArgument,
      ResultStatus.Forbidden => StatusCode.PermissionDenied,
      ResultStatus.Unauthorized => StatusCode.Unauthenticated,
      ResultStatus.Invalid => StatusCode.InvalidArgument,
      ResultStatus.NotFound => StatusCode.NotFound,
      ResultStatus.Conflict => StatusCode.Aborted,
      ResultStatus.CriticalError => StatusCode.Unknown,
      ResultStatus.Unavailable => StatusCode.Unavailable,
      _ => StatusCode.Unknown,
    };
  }
}

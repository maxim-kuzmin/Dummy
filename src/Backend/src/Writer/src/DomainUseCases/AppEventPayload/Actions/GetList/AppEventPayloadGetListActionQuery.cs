namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record AppEventPayloadGetListActionQuery(AppEventPayloadPageQuery CountQuery) :
  AppEventPayloadListQuery(CountQuery),
  IQuery<Result<AppEventPayloadListDTO>>;

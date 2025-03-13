namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppEventPayloadGetListActionQuery(AppEventPayloadPageQuery PageQuery) :
  AppEventPayloadListQuery(PageQuery),
  IQuery<Result<AppEventPayloadListDTO>>;

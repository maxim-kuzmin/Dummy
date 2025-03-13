using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Query.Sections;

namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record AppEventPayloadGetListActionQuery(
  QueryPageSection? Page,
  AppEventPayloadQueryFilterSection? Filter) : IQuery<Result<AppEventPayloadListDTO>>;

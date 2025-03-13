﻿using Makc.Dummy.Writer.DomainUseCases.AppEvent.Query.Sections;

namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка событий приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record AppEventGetListActionQuery(
  QueryPageSection? Page,
  AppEventQueryFilterSection? Filter) : IQuery<Result<AppEventListDTO>>;

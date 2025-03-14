﻿namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequest, IEnumerable<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetListEndpointSettings.Route);
    //AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    DummyItemGetListActionQuery query = new(
      new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc),
      new DummyItemGetListActionQueryFilter(request.Query));

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

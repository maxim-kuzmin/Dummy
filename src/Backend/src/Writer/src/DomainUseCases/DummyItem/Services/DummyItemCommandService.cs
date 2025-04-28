namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemCommandService(IMediator _mediator) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public Task<Result> OnEntityChanged(EntityChange<DummyItemEntity> entityChange, CancellationToken cancellationToken)
  {
    int position = 1;

    var deleted = entityChange.Deleted;
    var inserted = entityChange.Inserted;

    long entityId = 0;
    AppEventPayloadData? data = null;    

    if (inserted != null)
    {
      entityId = inserted.Id;

      data = [];

      if (inserted.Name != deleted?.Name)
      {
        data[nameof(inserted.Name)] = inserted.Name;
      }      
    }
    else if (deleted != null)
    {
      entityId = deleted.Id;
    }

    AppEventPayload payload = new(
      AppEntityNameEnum.DummyItem.ToString(),
      deleted?.ConcurrencyToken,
      inserted?.ConcurrencyToken,
      entityId.ToString(),
      data != null ? JsonSerializer.Serialize(data) : null,
      position);

    AppOutboxSaveActionCommand command = new(
      AppEventNameEnum.DummyItemChanged.ToString(),
      [payload]);

    return _mediator.Send(command, cancellationToken);
  }
}

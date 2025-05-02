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
    var deleted = entityChange.Deleted;
    var inserted = entityChange.Inserted;

    AppEventPayloadWithDataAsDictionary payload = new()
    {
      EntityName = AppEntityNameEnum.DummyItem.ToString(),
      Position = 1
    };

    if (inserted != null)
    {
      payload.EntityId = inserted.Id.ToString();

      payload.EntityConcurrencyTokenToInsert = inserted.ConcurrencyToken;

      if (inserted.Name != deleted?.Name)
      {
        payload.Data[nameof(inserted.Name)] = inserted.Name;
      }      
    }
    else if (deleted != null)
    {
      payload.EntityId = deleted.Id.ToString();

      payload.EntityConcurrencyTokenToDelete = deleted.ConcurrencyToken;
    }

    AppOutboxSaveActionCommand command = new(
      AppEventNameEnum.DummyItemChanged.ToString(),
      [payload.ToAppEventPayloadWithDataAsString()]);

    return _mediator.Send(command, cancellationToken);
  }
}

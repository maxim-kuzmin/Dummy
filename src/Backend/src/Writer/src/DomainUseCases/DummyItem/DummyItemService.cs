namespace Makc.Dummy.Writer.DomainUseCases.DummyItem;

/// <summary>
/// Сервис фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemService(IMediator _mediator) : IDummyItemService
{
  /// <inheritdoc/>
  public Task<Result> OnEntityChanged(EntityChange<DummyItemEntity> entityChange, CancellationToken cancellationToken)
  {
    AppOutboxSaveActionCommand command = new(AppEventNameEnum.DummyItemChanged, [entityChange]);

    return _mediator.Send(command, cancellationToken);
  }
}

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
    AppOutboxSaveActionCommand command = new(AppEventNameEnum.DummyItemChanged, [entityChange]);

    return _mediator.Send(command, cancellationToken);
  }
}

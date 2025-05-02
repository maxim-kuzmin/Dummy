namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemCommandService(IMediator _mediator) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public Task<Result> OnEntityChanged(AppEventPayloadWithDataAsDictionary payload, CancellationToken cancellationToken)
  {
    payload.Position = 1;

    AppOutboxSaveActionCommand command = new(
      AppEventNameEnum.DummyItemChanged.ToString(),
      [payload.ToAppEventPayloadWithDataAsString()]);

    return _mediator.Send(command, cancellationToken);
  }
}

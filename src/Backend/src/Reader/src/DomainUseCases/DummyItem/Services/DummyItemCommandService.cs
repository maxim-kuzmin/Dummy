namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
public class DummyItemCommandService : IDummyItemCommandService
{
  /// <inheritdoc/>
  public Task<Result> OnEntityChanged(AppEventPayloadWithDataAsDictionary payload, CancellationToken cancellationToken)
  {
    return Task.FromResult(Result.Success());
  }
}

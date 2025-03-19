namespace Makc.Dummy.Reader.Infrastructure.Core.DummyItem;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class DummyItemResources(IStringLocalizer<DummyItemResources> _stringLocalizer) : IDummyItemResources
{
  /// <inheritdoc/>
  public string GetConcurrencyTokenIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:ConcurrencyTokenIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetIdIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:IdIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:NameIsEmpty"];
  }
}

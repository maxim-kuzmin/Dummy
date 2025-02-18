namespace Makc.Dummy.Shared.Core.DeepCopy;

/// <summary>
/// Способное к глубокому копированию.
/// </summary>
public interface IDeepCopyable
{
  /// <summary>
  /// Глубоко копировать.
  /// </summary>
  /// <returns>Глубокая копия.</returns>
  object DeepCopy();
}

namespace Makc.Dummy.Shared.Core.App.Command.Results;

/// <summary>
/// Результат команды приложения без значения.
/// </summary>
/// <param name="Data">Данные.</param>
public record AppCommandResultWithoutValue(Result Data) : AppCommandResult
{
}

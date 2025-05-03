namespace Makc.Dummy.Shared.Core.App.Command.Results;

/// <summary>
/// Результат команды приложения со значением.
/// </summary>
/// <typeparam name="TValue">Тип значения.</typeparam>
/// <param name="Data">Данные.</param>
public record AppCommandResultWithValue<TValue>(Result<TValue> Data) : AppCommandResult
{
}

namespace Makc.Dummy.Shared.Domain.UseCases.Db.SQL;

/// <summary>
/// Команда базы данных SQL.
/// </summary>
public class DbSQLCommand
{
  private readonly Dictionary<string, object> _parameters = [];

  /// <summary>
  /// Построитель текста. В тех местах, куда должны быть подставлены значения параметров, должны быть указаны их имена.
  /// </summary>
  public StringBuilder TextBuilder { get; } = new();

  /// <summary>
  /// Добавить параметр.
  /// </summary>
  /// <param name="name">Имя. Должно начинаться с символа '@'.</param>
  /// <param name="value">Значение.</param>
  public void AddParameter(string name, object value)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(nameof(name));

    if (!name.StartsWith('@'))
    {
      throw new ArgumentException("The parameter name must start with the @ symbol", nameof(name));
    }

    _parameters[name] = value;
  }

  /// <summary>
  /// Копировать параметры в указанную команду базы данных.
  /// </summary>
  ///<param name="dbCommand">Команда базы данных, в которую копируются параметры.</param>
  public void CopyParametersTo(DbSQLCommand dbCommand)
  {
    foreach (var parameter in _parameters)
    {
      dbCommand.AddParameter(parameter.Key, parameter.Value);
    }
  }

  /// <summary>
  /// Получить параметры.
  /// </summary>
  /// <returns>Параметры.</returns>
  public IEnumerable<KeyValuePair<string, object>> GetParameters()
  {
    return _parameters.AsEnumerable();
  }

  /// <summary>
  /// Преобразовать к форматируемой строке.
  /// </summary>
  /// <returns>Форматируемая строка.</returns>
  public FormattableString? ToFormattableString()
  {
    if (_parameters.Count == 0)
    {
      return null;
    }

    var text = ToString();

    List<object> parameters = new(_parameters.Count);

    var parameterIndex = 0;

    foreach (var parameterName in _parameters.Keys)
    {
      parameters.Add(_parameters[parameterName]);

      text = text.Replace(parameterName, $"{{{parameterIndex++}}}");
    }

    return FormattableStringFactory.Create(text, [.. parameters]);
  }

  /// <inheritdoc/>
  public sealed override string ToString()
  {
    return TextBuilder.ToString();
  }
}

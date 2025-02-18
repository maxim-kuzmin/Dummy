namespace Makc.Dummy.Gateway.Infrastructure.Grpc.DummyItem.Action.Command;

/// <summary>
/// Расширения команд действия с фиктивным предметом.
/// </summary>
public static class DummyItemActionCommandExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по созданию фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по созданию фиктивного предмета.</returns>
  public static DummyItemCreateActionRequest ToDummyItemCreateActionGrpcRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionRequest
    {
      Name = command.Name,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по удалению фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по удалению фиктивного предмета.</returns>
  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionRequest
    {
      Id = command.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по обновлению фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по обновлению фиктивного предмета.</returns>
  public static DummyItemUpdateActionRequest ToDummyItemUpdateActionRequest(
    this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionRequest
    {
      Id = command.Id,
      Name = command.Name,
    };
  }
}

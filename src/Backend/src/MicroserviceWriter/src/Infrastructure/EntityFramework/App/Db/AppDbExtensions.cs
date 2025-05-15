namespace Makc.Dummy.MicroserviceWriter.Infrastructure.EntityFramework.App.Db;

/// <summary>
/// Расширения базы данных.
/// </summary>
public static class AppDbExtensions
{
  /// <summary>
  /// Заполнить тестовыми данными.
  /// </summary>
  /// <param name="appDbContext">Контекст базы данных приложения.</param>  
  /// <param name="appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
  /// <param name="mediator">Медиатор.</param>  
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  public async static Task PopulateWithTestData(
    this AppDbContext appDbContext,
    IAppDbSQLExecutionContext appDbExecutionContext,
    IMediator mediator,
    CancellationToken cancellationToken)
  {
    var isSeeded = await appDbContext.DummyItem.AnyAsync(cancellationToken).ConfigureAwait(false);

    if (isSeeded)
    {
      return;
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await CreateDummyItems(mediator, cancellationToken).ConfigureAwait(false);
    }

    await appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);
  }

  private static DummyItemSaveActionCommand CreateDummyItemSaveActionCommand(string name)
  {
    return new(false, 0, name);
  }

  private static async Task<List<DummyItemSingleDTO>> CreateDummyItems(
    IMediator mediator,
    CancellationToken cancellationToken)
  {
    DummyItemSaveActionCommand[] commands = [
      CreateDummyItemSaveActionCommand("Delba de Oliveira"),
      CreateDummyItemSaveActionCommand("Lee Robinson"),
      CreateDummyItemSaveActionCommand("Hector Simpson"),
      CreateDummyItemSaveActionCommand("Steven Tey"),
      CreateDummyItemSaveActionCommand("Steph Dietz"),
      CreateDummyItemSaveActionCommand("Michael Novotny"),
      CreateDummyItemSaveActionCommand("Evil Rabbit"),
      CreateDummyItemSaveActionCommand("Emil Kowalski"),
      CreateDummyItemSaveActionCommand("Amy Burns"),
      CreateDummyItemSaveActionCommand("Balazs Orban"),
    ];

    List<DummyItemSingleDTO> result = new(commands.Length);

    foreach (var command in commands)
    {
      var actionResult = await mediator.Send(command, cancellationToken).ConfigureAwait(false);

      result.Add(actionResult.Value);
    }

    return result;
  }
}

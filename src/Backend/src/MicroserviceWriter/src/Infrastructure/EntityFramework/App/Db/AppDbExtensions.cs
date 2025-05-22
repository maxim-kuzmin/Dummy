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

  private static DummyItemSaveActionRequest CreateDummyItemSaveActionRequest(string name)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: name));

    return new(command);
  }

  private static async Task<List<DummyItemSingleDTO>> CreateDummyItems(
    IMediator mediator,
    CancellationToken cancellationToken)
  {
    DummyItemSaveActionRequest[] requests = [
      CreateDummyItemSaveActionRequest("Delba de Oliveira"),
      CreateDummyItemSaveActionRequest("Lee Robinson"),
      CreateDummyItemSaveActionRequest("Hector Simpson"),
      CreateDummyItemSaveActionRequest("Steven Tey"),
      CreateDummyItemSaveActionRequest("Steph Dietz"),
      CreateDummyItemSaveActionRequest("Michael Novotny"),
      CreateDummyItemSaveActionRequest("Evil Rabbit"),
      CreateDummyItemSaveActionRequest("Emil Kowalski"),
      CreateDummyItemSaveActionRequest("Amy Burns"),
      CreateDummyItemSaveActionRequest("Balazs Orban"),
    ];

    List<DummyItemSingleDTO> result = new(requests.Length);

    foreach (var request in requests)
    {
      var actionResult = await mediator.Send(request, cancellationToken).ConfigureAwait(false);

      result.Add(actionResult.Value);
    }

    return result;
  }
}

﻿namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.App;

/// <summary>
/// Данные приложения.
/// </summary>
public static class AppData
{
  /// <summary>
  /// Инициализировать.
  /// </summary>
  /// <param name="appDbContext">Контекст базы данных приложения.</param>
  /// <param name="shouldDbBePopulatedWithTestData">Следует ли заполнять базу данных тестовыми данными?</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  public static Task Initialize(
    AppDbContext appDbContext,
    bool shouldDbBePopulatedWithTestData,
    CancellationToken cancellationToken)
  {
    return shouldDbBePopulatedWithTestData
      ? PopulateDbWithTestDataAsync(appDbContext, cancellationToken)
      : Task.CompletedTask;
  }

  private static List<DummyItemEntity> CreateDummyItems()
  {
    return [
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Delba de Oliveira"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Lee Robinson"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Hector Simpson"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Steven Tey"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Steph Dietz"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Michael Novotny"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Evil Rabbit"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Emil Kowalski"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Amy Burns"
      },
      new()
      {
        ConcurrencyToken = Guid.NewGuid(),
        Name = "Balazs Orban"
      },
    ];
  }

  private static async Task PopulateDbWithTestDataAsync(AppDbContext appDbContext, CancellationToken cancellationToken)
  {
    var isSeeded = await appDbContext.DummyItem.AnyAsync(cancellationToken).ConfigureAwait(false);

    if (isSeeded)
    {
      return;
    }

    using var tran = await appDbContext.Database.BeginTransactionAsync(cancellationToken);

    appDbContext.DummyItem.AddRange(CreateDummyItems());

    await appDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    tran.Commit();
  }
}

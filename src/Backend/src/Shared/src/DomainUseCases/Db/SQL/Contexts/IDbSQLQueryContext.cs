﻿namespace Makc.Dummy.Shared.DomainUseCases.Db.SQL.Contexts;

/// <summary>
/// Интерфейс контекста запроса базы данных SQL.
/// </summary>
public interface IDbSQLQueryContext
{
  /// <summary>
  /// Получить первый элемент или значение по умолчанию асинхронно.
  /// </summary>
  /// <typeparam name="T">Тип возвращаемого элемента.</typeparam>
  /// <param name="dbCommand">Команда базы данных.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Первое или по умолчанию.</returns>
  Task<T?> GetFirstOrDefaultAsync<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список асинхронно.
  /// </summary>
  /// <typeparam name="T">Тип элемента возвращаемого списка.</typeparam>
  /// <param name="dbCommand">Команда базы данных.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список.</returns>
  Task<List<T>> GetListAsync<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken);
}

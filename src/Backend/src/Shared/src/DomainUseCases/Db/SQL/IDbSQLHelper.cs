﻿namespace Makc.Dummy.Shared.DomainUseCases.Db.SQL;

/// <summary>
/// Интерфейс помощника базы данных SQL.
/// </summary>
public interface IDbSQLHelper
{
  /// <summary>
  /// Добавить получение страницы.
  /// </summary>
  /// <param name="dbCommand">Команда базы данных.</param>
  /// <param name="page">Страница.</param>
  void AddPagination(DbSQLCommand dbCommand, QueryPageSection? page);

  /// <summary>
  /// Добавить сортировку.
  /// </summary>
  /// <param name="dbCommand">Команда базы данных.</param>
  /// <param name="sort">Сортировка.</param>
  /// <param name="defaultSort">Сортировка по умолчанию.</param>
  /// <param name="funcToCreateOrderByField">Функция для создания поля в выражении "order by".</param>
  void AddSorting(
    DbSQLCommand dbCommand,
    QuerySortSection? sort,
    QuerySortSection defaultSort,
    Func<string, string> funcToCreateOrderByField);
}

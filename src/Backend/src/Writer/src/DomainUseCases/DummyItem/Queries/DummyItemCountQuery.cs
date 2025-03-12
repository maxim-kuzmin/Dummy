﻿namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос количества фиктивных предметов.
/// </summary>
public record DummyItemCountQuery : CountQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public DummyItemGetListActionQueryFilter? Filter { get; set; }
}

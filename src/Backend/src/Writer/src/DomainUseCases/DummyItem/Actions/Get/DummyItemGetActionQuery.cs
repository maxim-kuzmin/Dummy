﻿namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
public record DummyItemGetActionQuery : DummyItemSingleQuery, IQuery<Result<DummyItemSingleDTO>>;

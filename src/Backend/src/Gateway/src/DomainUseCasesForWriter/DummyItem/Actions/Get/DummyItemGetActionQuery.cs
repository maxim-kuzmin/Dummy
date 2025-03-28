﻿namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemGetActionQuery(long Id) : IQuery<Result<DummyItemSingleDTO>>;

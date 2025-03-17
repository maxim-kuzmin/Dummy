﻿namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.Delete;

/// <summary>
/// Команда действия по удалению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemDeleteActionCommand(string ObjectId) : ICommand<Result>;

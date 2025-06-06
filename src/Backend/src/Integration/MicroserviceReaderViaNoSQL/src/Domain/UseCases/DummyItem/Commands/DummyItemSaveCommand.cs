﻿namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Commands;

/// <summary>
/// Команда сохранения фиктивного предмета.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Data">Данные.</param>
public record DummyItemSaveCommand(
  bool IsUpdate,
  string? ObjectId,
  DummyItemCommandDataSection Data);

﻿namespace Makc.Dummy.Shared.Domain.UseCases.DTOs;

/// <summary>
/// Объект передачи данных страницы.
/// </summary>
/// <typeparam name="TItem">Тип элемента.</typeparam>
/// <typeparam name="TTotalCount">Тип общего количества.</typeparam>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record PageDTO<TItem, TTotalCount>(
  List<TItem> Items,
  TTotalCount TotalCount)
  where TItem : class
  where TTotalCount: struct;

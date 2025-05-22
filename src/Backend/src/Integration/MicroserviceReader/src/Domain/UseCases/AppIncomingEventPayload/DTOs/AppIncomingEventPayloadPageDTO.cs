namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных страницы полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppIncomingEventPayloadPageDTO(
  List<AppIncomingEventPayloadSingleDTO> Items,
  long TotalCount) : PageDTO<AppIncomingEventPayloadSingleDTO, long>(Items, TotalCount);

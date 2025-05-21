namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppOutgoingEventPayloadPageDTO(
  List<AppOutgoingEventPayloadSingleDTO> Items,
  long TotalCount) : PageDTO<AppOutgoingEventPayloadSingleDTO, long>(Items, TotalCount);

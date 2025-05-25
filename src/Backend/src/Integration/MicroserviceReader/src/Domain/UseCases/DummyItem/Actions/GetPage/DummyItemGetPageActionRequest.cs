namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.DummyItem.Actions.GetPage;

/// <summary>
/// Запрос действия по получению страницы фиктивных предметов.
/// </summary>
/// <param name="Query">Запрос.</param>
public record DummyItemGetPageActionRequest(DummyItemPageQuery Query) :
  IQuery<Result<DummyItemPageDTO>>;

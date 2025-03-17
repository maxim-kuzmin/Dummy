﻿namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.App.Services;

/// <summary>
/// Сервис команд приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppCommandService(IHttpClientFactory _httpClientFactory) : IAppCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginDTO>> Login(
    AppLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.DummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AppSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}

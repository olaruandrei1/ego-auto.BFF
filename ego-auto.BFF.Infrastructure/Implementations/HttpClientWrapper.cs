using ego_auto.BFF.Application.Contracts;
using System.Net.Http;
using System.Text.Json;

namespace ego_auto.BFF.Infrastructure.Implementations;

public sealed class HttpClientWrapper(IHttpClientFactory _factory, string? _httpClient = null) : IHttpClientWrapper
{
    public async Task<TOut?> SendAsync<TIn, TOut>(HttpMethod method, string url, TIn content, CancellationToken cancellationToken = default, string mediaType = "application/json")
    {
        var client = GetHttpClient();

        HttpRequestMessage requestMessage = new HttpRequestMessage(method, url);

        if (content != null)
        {
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(content),
                System.Text.Encoding.UTF8,
                mediaType
            );
            requestMessage.Content = jsonContent;
        }

        var response = await client.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<TOut>
            (
                await response.Content.ReadAsStringAsync(cancellationToken)
            );
    }

    public async Task<TOut?> GetAsync<TOut>(string url, CancellationToken cancellationToken = default)
    {
        var client = GetHttpClient();

        var response = await client.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<TOut>
            (
                await response.Content.ReadAsStringAsync(cancellationToken)
            );
    }

    private HttpClient GetHttpClient()
    => string.IsNullOrEmpty(_httpClient) ? _factory.CreateClient() : _factory.CreateClient(_httpClient);
}

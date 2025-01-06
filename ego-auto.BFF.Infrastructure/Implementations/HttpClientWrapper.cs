using ego_auto.BFF.Application.Contracts;
using System.Text.Json;

namespace ego_auto.BFF.Infrastructure.Implementations;

public sealed class HttpClientWrapper(HttpClient _httpClient) : IHttpClientWrapper
{
    public async Task<TOut> PostAsync<TIn, TOut>(string url, TIn content, CancellationToken cancellationToken = default)
    {
        StringContent jsonContent = new
            (
                System.Text.Json.JsonSerializer.Serialize(content),
                System.Text.Encoding.UTF8,
                "application/json"
            );

        var response = await _httpClient.PostAsync(requestUri: url, content: jsonContent, cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<TOut>
            (
                await response.Content.ReadAsStringAsync(cancellationToken)
            );
    }

    public async Task<TOut> PutAsync<TIn, TOut>(string url, TIn content, CancellationToken cancellationToken = default)
    {
        var jsonContent = new StringContent(
            content: System.Text.Json.JsonSerializer.Serialize(content),
            System.Text.Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PutAsync(url, jsonContent, cancellationToken);

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<TOut>
           (
               await response.Content.ReadAsStringAsync(cancellationToken)
           );
    }
}

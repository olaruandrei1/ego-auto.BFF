namespace ego_auto.BFF.Application.Contracts;

public interface IHttpClientWrapper
{
    Task<TOut?> GetAsync<TOut>(string url, CancellationToken cancellationToken = default);
    Task<TOut?> SendAsync<TIn, TOut>(HttpMethod method, string url, TIn content = default, CancellationToken cancellationToken = default, string mediaType = "application/json");
}
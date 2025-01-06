namespace ego_auto.BFF.Application.Contracts;

public interface IHttpClientWrapper
{
    Task<TOut> PutAsync<TIn, TOut>(string url, TIn content, CancellationToken cancellationToken = default);
    Task<TOut> PostAsync<TIn, TOut>(string url, TIn content, CancellationToken cancellationToken = default);
}
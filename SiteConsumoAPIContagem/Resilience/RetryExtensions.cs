using Polly;
using Polly.Retry;
using SiteConsumoAPIContagem.Logging;

namespace SiteConsumoAPIContagem.Resilience;

public static class RetryExtensions
{
    public static AsyncRetryPolicy<HttpResponseMessage> CreatePolicy(int retryCount)
    {
        return Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .RetryAsync(retryCount, onRetry: (message, retryCount) =>
            {
                string msg = $"Retentativa: {retryCount}";
                Console.Out.WriteLineAsync(msg);
                LogFileHelper.WriteMessage(msg);
            });
    }
}
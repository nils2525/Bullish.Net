using Bullish.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBullishClientExchangeApiAccount
    {
        /// <summary>
        /// <a href="https://api.exchange.bullish.com/docs/api/rest/trading-api/v2/#get-/v1/users/hmac/login" />
        /// </summary>
        Task<WebCallResult<BullishAuthResponse>> LoginHmac(CancellationToken ct = default);
    }
}

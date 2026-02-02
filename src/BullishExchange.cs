using Bullish.Net.Converters;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;

namespace Bullish.Net
{
    /// <summary>
    /// CryptoCom exchange information and configuration
    /// </summary>
    public static class BullishExchange
    {
        internal static BullishSourceGenerationContext SerializerContext { get; } = new BullishSourceGenerationContext();

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bullish";

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string DisplayName => "Bullish.com";

        /// <summary>
        /// Url to exchange image
        /// </summary>
        public static string ImageUrl { get; } = "";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.Bullish.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            ""
            };

        /// <summary>
        /// Type of exchange
        /// </summary>
        public static ExchangeType Type { get; } = ExchangeType.CEX;

        /// <summary>
        /// Format a base and quote asset to a Crypto.com recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return $"{baseAsset.ToUpperInvariant()}_{quoteAsset.ToUpperInvariant()}";

            if (tradingMode.IsPerpetual())
                return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-PERP";

            if (deliverTime == null)
                throw new ArgumentException("DeliverDate required to format delivery futures symbol");

            return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-{deliverTime.Value.ToString("yyMMdd")}";
        }

        /// <summary>
        /// Rate limiter configuration for the CryptoCom API
        /// </summary>
        public static BullishRateLimiters RateLimiter { get; } = new BullishRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the CryptoCom API
    /// </summary>
    public class BullishRateLimiters
    {
        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal BullishRateLimiters()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Initialize();
        }

        private void Initialize()
        {
            Generic = new RateLimitGate("Generic")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, Array.Empty<IGuardFilter>(), 500, TimeSpan.FromSeconds(10), RateLimitWindowType.Sliding))
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, new LimitItemTypeFilter(RateLimitItemType.Request), 50, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));

            Generic.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate Generic { get; private set; }

    }
}

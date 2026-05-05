using Bullish.Net.Converters;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;

namespace Bullish.Net
{
    /// <summary>
    /// Bullish exchange information and configuration
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
        /// Format a base and quote asset to a Bullish recognized symbol
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
        /// Rate limiter configuration for the Bullish API
        /// </summary>
        public static BullishRateLimiters RateLimiter { get; } = new BullishRateLimiters();
    }
}

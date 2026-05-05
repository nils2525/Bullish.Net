using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;

namespace Bullish.Net
{
    /// <summary>
    /// Rate limiter configuration for the Bullish API
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
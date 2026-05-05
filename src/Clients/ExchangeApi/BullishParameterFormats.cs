using System.Globalization;

namespace Bullish.Net.Clients.ExchangeApi
{
    internal static class BullishParameterFormats
    {
        public static string FormatDateTime(DateTime time)
            => time.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
    }
}
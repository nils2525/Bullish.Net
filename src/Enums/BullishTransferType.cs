using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bullish.Net.Enums
{
    /// <summary>
    /// Transfer type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BullishTransferType>))]
    public enum BullishTransferType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("DEPOSIT")]
        Deposit,

        /// <summary>
        /// Withdrawal
        /// </summary>
        [Map("WITHDRAWAL")]
        Withdrawal,

        /// <summary>
        /// Transfer
        /// </summary>
        [Map("TRANSFER")]
        Transfer
    }
}

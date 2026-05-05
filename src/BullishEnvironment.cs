using Bullish.Net.Objects;
using CryptoExchange.Net.Objects;

namespace Bullish.Net
{
    /// <summary>
    /// Bullish environments
    /// </summary>
    public class BullishEnvironment : TradeEnvironment
    {
        /// <summary>
        /// Rest API address
        /// </summary>
        public string RestClientAddress { get; }

        /// <summary>
        /// Socket API address
        /// </summary>
        public string SocketClientAddress { get; }

        /// <summary>
        /// Private Socket API address
        /// </summary>
        public string SocketClientPrivateAddress { get; }

        internal BullishEnvironment(
            string name,
            string restAddress,
            string streamAddress,
            string? privateStreamAddress = null) :
            base(name)
        {
            RestClientAddress = restAddress;
            SocketClientAddress = streamAddress;
            SocketClientPrivateAddress = privateStreamAddress ?? streamAddress;
        }

        /// <summary>
        /// ctor for DI, use <see cref="CreateCustom"/> for creating a custom environment
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BullishEnvironment() : base(TradeEnvironmentNames.Live)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        { }

        /// <summary>
        /// Get the Bullish environment by name
        /// </summary>
        public static BullishEnvironment? GetEnvironmentByName(string? name)
         => name switch
         {
             TradeEnvironmentNames.Live => Live,
             "" => Live,
             null => Live,
             _ => default
         };

        /// <summary>
        /// Live environment
        /// </summary>
        public static BullishEnvironment Live { get; }
            = new BullishEnvironment(TradeEnvironmentNames.Live,
                                     BullishApiAddresses.Default.RestClientAddress,
                                     BullishApiAddresses.Default.SocketClientPublicAddress,
                                     BullishApiAddresses.Default.SocketClientPrivateAddress);

        /// <summary>
        /// Create a custom environment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="spotRestAddress"></param>
        /// <param name="spotSocketStreamsAddress"></param>
        /// <returns></returns>
        public static BullishEnvironment CreateCustom(
                        string name,
                        string spotRestAddress,
                        string spotSocketStreamsAddress,
                        string? spotSocketPrivateAddress = null)
            => new BullishEnvironment(name, spotRestAddress, spotSocketStreamsAddress, spotSocketPrivateAddress);
    }
}

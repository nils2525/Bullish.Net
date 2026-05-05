namespace Bullish.Net.Objects
{
    /// <summary>
    /// Api addresses
    /// </summary>
    public class BullishApiAddresses
    {
        /// <summary>
        /// The address used by the BullishRestClient for the public API
        /// </summary>
        public string RestClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BullishRestClient for the private API
        /// </summary>
        public string RestClientPrivateAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BullishSocketClient for the public websocket API
        /// </summary>
        public string SocketClientPublicAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BullishSocketClient for the private websocket API
        /// </summary>
        public string SocketClientPrivateAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the Bullish API
        /// </summary>
        public static BullishApiAddresses Default = new BullishApiAddresses
        {
            RestClientAddress = "https://api.exchange.bullish.com",
            RestClientPrivateAddress = "https://registered.api.exchange.bullish.com",
            SocketClientPublicAddress = "wss://api.exchange.bullish.com",
            SocketClientPrivateAddress = "wss://api.exchange.bullish.com"
        };
    }
}

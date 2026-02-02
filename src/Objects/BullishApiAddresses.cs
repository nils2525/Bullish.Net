namespace Bullish.Net.Objects
{
    /// <summary>
    /// Api addresses
    /// </summary>
    public class BullishApiAddresses
    {
        /// <summary>
        /// The address used by the CryptoComRestClient for the API
        /// </summary>
        public string RestClientAddress { get; set; } = "";

        public string RestClientPrivateAddress { get; set; } = "";

        /// <summary>
        /// The address used by the CryptoComSocketClient for the websocket API
        /// </summary>
        public string SocketClientPublicAddress { get; set; } = "";

        public string SocketClientPrivateAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the CryptoCom API
        /// </summary>
        public static BullishApiAddresses Default = new BullishApiAddresses
        {
            RestClientAddress = "https://api.exchange.bullish.com",
            RestClientPrivateAddress = "https://registered.api.exchange.bullish.com",
            SocketClientPublicAddress = "wss://api.exchange.bullish.com",
            SocketClientPrivateAddress = "wss://registered.api.exchange.bullish.com"
        };
    }
}

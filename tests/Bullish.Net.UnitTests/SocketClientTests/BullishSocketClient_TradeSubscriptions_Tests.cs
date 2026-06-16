using System.Text.Json;
using Bullish.Net.Clients;
using Bullish.Net.Clients.ExchangeApi;
using CryptoExchange.Net.Testing;

namespace Bullish.Net.UnitTests.SocketClientTests
{
    [TestClass]
    public class BullishSocketClient_TradeSubscriptions_Tests
    {
        [TestMethod]
        public async Task TradeSubscriptions_ManyPublicSymbols_ReusesSingleMarketDataConnection_TestAsync()
        {
            // Reproduces the Analyzer startup failure mode where many one-symbol trade subscriptions created excessive Bullish WebSocket handshakes.
            using var client = new BullishSocketClient();
            var socket = TestHelpers.ConfigureSocketClient(client, "wss://api.exchange.bullish.com/trading-api/v1/market-data/trades");
            socket.OnMessageSend += data =>
            {
                using var document = JsonDocument.Parse(data);
                var id = document.RootElement.GetProperty("id").GetString();
                socket.InvokeMessage($"{{\"jsonrpc\":\"2.0\",\"id\":\"{id}\",\"result\":{{\"responseCode\":\"200\",\"responseCodeName\":\"OK\",\"message\":\"Successfully subscribed\"}}}}");
            };

            for (var i = 0; i < 30; i++)
            {
                var result = await client.ExchangeApi.SubscribeToTradeUpdatesAsync($"BTC{i}USDC", _ => { });
                Assert.IsTrue(result.Success, result.Error?.ToString());
            }

            var exchangeApi = (BullishSocketClientExchangeApi)client.ExchangeApi;
            Assert.AreEqual(1, exchangeApi.CurrentConnections, "Bullish public trade subscriptions should fan out on one connection.");
            Assert.AreEqual(TimeSpan.FromSeconds(60), exchangeApi.ClientOptions.ConnectDelayAfterRateLimited, "Bullish 429 handshakes should install a retry-after delay.");
        }
    }
}

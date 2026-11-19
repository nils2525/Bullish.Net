using System.Collections.Concurrent;
using System.Text.Json;
using Bullish.Net.Clients;
using Bullish.Net.Objects.Options;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bullish.Net.UnitTests.SocketClientTests;

[TestClass]
public class BullishSocketClient_Unsubscribe_Tests
{
    [TestMethod]
    public async Task UnsubscribeAsync_LateSuccessIsHandledAndUnexpectedResponsesStillWarn()
    {
        using var warnings = new WarningLog();
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddProvider(warnings));
        using var client = new BullishSocketClient(Options.Create(new BullishSocketOptions()), loggerFactory);
        var socket = TestHelpers.ConfigureSocketClient(client, "wss://api.exchange.bullish.com/trading-api/v1/market-data/trades");
        string? unsubscribeId = null;
        socket.OnMessageSend += data =>
        {
            using var request = JsonDocument.Parse(data);
            var id = request.RootElement.GetProperty("id").GetString();
            if (request.RootElement.GetProperty("method").GetString() == "unsubscribe")
                unsubscribeId = id;
            else
                socket.InvokeMessage($$$"""{"jsonrpc":"2.0","id":"{{{id}}}","result":{"message":"Successfully subscribed","responseCode":200,"responseCodeName":"OK"}}""");
        };

        var first = await client.ExchangeApi.SubscribeToTradeUpdatesAsync("BTCUSDC", _ => { });
        var second = await client.ExchangeApi.SubscribeToTradeUpdatesAsync("ETHUSDC", _ => { });
        Assert.IsTrue(first.Success && second.Success);
        // The second subscription keeps the shared socket open. Send the acknowledgement after unsubscribe completes.
        await client.UnsubscribeAsync(first.Data).WaitAsync(TimeSpan.FromSeconds(3));
        Assert.IsNotNull(unsubscribeId);
        socket.InvokeMessage($$$"""{"jsonrpc":"2.0","id":"{{{unsubscribeId}}}","result":{"message":"Successfully unsubscribed","responseCode":200,"responseCodeName":"OK"}}""");
        Assert.IsFalse(warnings.Messages.Any(m => m.Contains($"identifier {unsubscribeId}.")));

        socket.InvokeMessage("""{"jsonrpc":"2.0","id":"123456","result":{"message":"Successfully subscribed","responseCode":200,"responseCodeName":"OK"}}""");
        socket.InvokeMessage("""{"jsonrpc":"2.0","id":"123457","result":{"message":"Successfully unsubscribed","responseCode":400,"responseCodeName":"ERROR"}}""");
        Assert.IsTrue(warnings.Messages.Any(m => m.Contains("identifier 123456.")));
        Assert.IsTrue(warnings.Messages.Any(m => m.Contains("identifier 123457.")));
    }

    private sealed class WarningLog : ILoggerProvider, ILogger
    {
        public ConcurrentQueue<string> Messages { get; } = new();

        public ILogger CreateLogger(string categoryName) => this;
        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public void Dispose() { }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
                Messages.Enqueue(formatter(state, exception));
        }
    }
}

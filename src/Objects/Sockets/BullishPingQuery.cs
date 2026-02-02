using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;

namespace Bullish.Net.Objects.Sockets
{
    internal class BullishPingQuery : Query<BullishSocketResponse>
    {
        public BullishPingQuery(bool authenticated, int weight = 1) : base(new BullishSocketRequest("keepalivePing"), authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<BullishSocketResponse>(((BullishSocketRequest)Request).Id, HandleMessage);
        }

        public CallResult<BullishSocketResponse> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BullishSocketResponse message)
        {
            return new CallResult<BullishSocketResponse>(message, originalData, null);
        }
    }
}

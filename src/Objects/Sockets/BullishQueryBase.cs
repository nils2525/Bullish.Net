using Bullish.Net.Objects.Internal;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;

namespace Bullish.Net.Objects.Sockets
{
    internal abstract class BullishQueryBase<T> : Query<T>
        where T : BullishSocketResponseBase
    {
        public BullishQueryBase(BullishSocketRequest request, string listenerIdentifier, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateForQuery<T>(new[] { listenerIdentifier, "error" }, HandleMessage);
        }

        public BullishQueryBase(BullishSocketRequest request, bool authenticated, int weight = 1)
            : this(request, request.Id, authenticated, weight)
        { }

        public CallResult<T> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, T message)
        {
            if (message is BullishSocketResponse res && res.Error != null)
                return CallResult.Fail<T>(new ServerError(res.Error.Code, new(CryptoExchange.Net.Objects.Errors.ErrorType.Unknown, res.Error.Message)));

            return CallResult.Ok(message, originalData);
        }
    }
}

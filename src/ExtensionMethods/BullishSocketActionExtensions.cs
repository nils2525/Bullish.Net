using Bullish.Net.Enums;
using CryptoExchange.Net.Objects;

namespace Bullish.Net.ExtensionMethods
{
    public static class BullishSocketActionExtensions
    {
        public static SocketUpdateType ToSocketUpdateType(this BullishSocketAction action)
            => action switch
            {
                BullishSocketAction.Snapshot => SocketUpdateType.Snapshot,
                _ => SocketUpdateType.Update
            };
    }
}

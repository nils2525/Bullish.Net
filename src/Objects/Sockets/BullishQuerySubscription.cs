using Bullish.Net.Objects.Internal;

namespace Bullish.Net.Objects.Sockets
{
    internal class BullishQuerySubscription : BullishQueryBase<BullishSocketResponse>
    {
        public BullishQuerySubscription(BullishSocketRequest request, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        { }
    }
}
using Bullish.Net.Objects.Internal;

namespace Bullish.Net.Objects.Sockets
{
    internal class BullishQuery<T> : BullishQueryBase<BullishSocketResponse>
    {
        public BullishQuery(BullishSocketRequest request, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        { }
    }
}

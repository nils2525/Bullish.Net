using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bullish.Net.Enums;
using CryptoExchange.Net.Objects;

namespace Bitrue.Net.ExtensionMethods
{
    public static  class BullishSocketActionExtensions
    {
        public static SocketUpdateType ToCEN(this BullishSocketAction action)
            => action switch
            {
                BullishSocketAction.Snapshot => SocketUpdateType.Snapshot,
                _ => SocketUpdateType.Update
            };
    }
}

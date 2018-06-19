using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.Entities
{
   public static class ConvertSymbolTool
    {

        /// <summary>
        /// 火币btcusdt, bchbtc, rcneth 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string HBConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "&symbol=" + (coin.ToString() + currency.ToString()).ToLower();
        }



        /// <summary>
        ///  OKEx btcusdt, bchbtc, rcneth 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string OKConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return  (coin.ToString() + "_"+currency.ToString()).ToLower();
        }
    }
}

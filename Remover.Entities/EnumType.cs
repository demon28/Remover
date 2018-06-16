using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class EnumType
    {
        public enum CoinType
        {
            BTC=0,   //比特币
            LTC=1,   //莱特币
            ETH=2,   //以太坊
            EOS=3    //柚子
        }

        public enum CurrencyType
        {
            USDT=0,
            CNY=1
        }

        public enum ExchangeType
        {
            HuoBi=0,
            OKEX=1,
        }

        public enum SymbolType
        {
            btcusdt = 0,
            ltcusdt=1,
            ethusdt=2,
            eosusdt=3

        }

        /// <summary>
        /// btcusdt, bchbtc, rcneth 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string ConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "&symbol="+(coin.ToString() + currency.ToString()).ToLower();
        }
    }
}

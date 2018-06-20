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
            EOS=3,    //柚子
            TRX=4,    //波场
            NEO=5,    //小蚁
            XRP=6,   //瑞波币
            ETC=7,    //以太经典

        }

        public enum CurrencyType
        {
            USDT=0,
            CNY=1,
            USD=2
        }

        public enum ExchangeType
        {
            HuoBi=0,
            OKEX=1,
            Gate=2,
            BiAn=3,
            ZB=4
        }

        public enum SymbolType
        {
            btcusdt = 0,
            ltcusdt=1,
            ethusdt=2,
            eosusdt=3

        }

     
    }
}

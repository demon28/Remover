using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.CoinealAPI
{
    public static class ApiUrlList
    {

        //https://exchange-open-api.coineal.com


        /// <summary>
        /// 加参数为获取该币种价格
        /// </summary>
        public const string API_Ticker = "/open/api/get_ticker";


        /// <summary>
        /// 不加参数为获取该币种价格
        /// </summary>
        public const string API_Market = "/open/api/market";




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.BiAnAPI
{
    public static class ApiUrlList
    {

        //https://api.binance.com/api/v1/ticker/24hr


        /// <summary>
        /// 加参数为获取该币种价格
        /// </summary>
        public const string API_Ticker = "/api/v1/ticker/24hr";


        /// <summary>
        /// 不加参数为获取该币种价格
        /// </summary>
        public const string API_Market = "/api/v1/ticker/24hr";




    }
}

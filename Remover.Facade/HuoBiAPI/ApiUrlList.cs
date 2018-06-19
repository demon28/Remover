using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.HuoBiAPI
{
    internal static  class ApiUrlList
    {

        public  const  string huobi_host = "api.huobi.pro";

     
        public const string API_ACCOUNBT_BALANCE = "/v1/account/accounts/{0}/balance";
        public const string API_ACCOUNBT_ALL = "/v1/account/accounts";
        public const string API_ORDERS_PLACE = "/v1/order/orders/place";




        /// <summary>
        /// 获取聚合行情(Ticker)
        /// </summary>
        public const string API_Ticker = "/market/detail/merged";




    }
}

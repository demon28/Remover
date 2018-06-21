using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.GateAPI
{
    public static class ApiUrlList
    {
        public const string API_Ticker = "/api2/1/ticker/";

        /// <summary>
        /// 不加参数为所有币种
        /// </summary>
        public const string API_Market = "/api2/1/tickers";

    }
}

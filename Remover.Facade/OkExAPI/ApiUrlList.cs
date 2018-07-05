using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.OkExAPI
{
    public static class ApiUrlList
    {


        //https://www.okex.com/api/v1/tickers.do


            /// <summary>
            /// 加参数获取单个币价
            /// </summary>
        public const string API_Ticker = "/api/v1/ticker.do";
        
        /// <summary>
        /// 不加参数为所有币种
        /// </summary>
        public const string API_Market = "/api/v1/tickers.do";

    }
}

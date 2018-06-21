using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Facade.ZBAPI
{
    public static class ApiUrlList
    {
        //http://api.zb.com/data/v1/ticker


            /// <summary>
            /// 单个币种
            /// </summary>
        public const string API_Ticker = "/data/v1/ticker";


        /// <summary>
        /// 所有币价
        /// </summary>
        public const string API_Market = "/data/v1/allTicker";
    }
}

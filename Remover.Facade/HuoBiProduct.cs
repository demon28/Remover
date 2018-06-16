using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Entities.HuoBiAPI;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{

    /// <summary>
    /// 火币实例
    /// </summary>
    class HuoBiProduct : ExChangeBase
    {


        private string AccessKey, SeceretKey;

        HuoBiApiTool api;

        public  HuoBiProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new HuoBiApiTool(AccessKey, SeceretKey);
        }



        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency)
        {
            string Symbol = ConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(Entities.HuoBiAPI.ApiUrlList.API_Ticker, Symbol);

            return result.tick.ask[0];
            
        }
    }
}

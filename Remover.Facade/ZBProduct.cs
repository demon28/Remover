using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Entities.ZBRequsetModel;
using Remover.Facade.ZBAPI;

namespace Remover.Facade
{
   public class ZBProduct:ExChangeBase
    {

        private string AccessKey, SeceretKey;

        ZbAPIFacade api;

        public ZBProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new ZbAPIFacade(AccessKey, SeceretKey);
        }



        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency)
        {
            string Symbol = ConvertSymbolTool.ZBConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result.ticker.last <= 0)
            {
                return 0;
            }

            return result.ticker.last;

        }

      
    }
}

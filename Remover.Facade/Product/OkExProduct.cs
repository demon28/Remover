using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Entities.OKRequestModel;
using Remover.Facade.OkExAPI;
namespace Remover.Facade
{
    public class OkExProduct : ExChangeBase
    {



        private string ApiKey, SeceretKey;
        private OkExAPIFacade OkAPi;

        public OkExProduct(string apiKey,string seceretKey)
        {

            ApiKey = apiKey;
            SeceretKey = seceretKey;
            OkAPi = new OkExAPIFacade(ApiKey, SeceretKey);
        }


        public override string GetExchangeName()
        {
            return "OkEx";
        }
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string symbol = ConvertSymbolTool.OKConvertSymbol(coin, currency);

            TicketRequset ticket= OkAPi.GetTicker(symbol);

            if (ticket==null)
            {
                Alert("获取价格失败！");
                return 0;
            }

            return ticket.ticker.last;
        }
    }
}

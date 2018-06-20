using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Facade.GateAPI;
using Winner.Framework.Core.Facade;
using Remover.Entities.GateRequestModel;
namespace Remover.Facade
{
    public class GateProduct : ExChangeBase
    {

        private string Apikey,Seceretkey;
        GateAPIFacade gateAPI;

      
        public GateProduct(string apiKey,string seceretKey)
        {
            Apikey = apiKey;
            Seceretkey = seceretKey;

            gateAPI = new GateAPIFacade(Apikey, Seceretkey);
        }
        public override string GetExchangeName()
        {
            return "GateIO";
        }

        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.OKConvertSymbol(coin, currency);

            var result = gateAPI.SendRequestContent<TicketRequest>(ApiUrlList.Url_Ticker, Symbol);

            if (result.last== 0)
            {
                return 0;
            }

            return result.last;
        }
    }
}

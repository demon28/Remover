using System;
using System.Collections;
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


        public override Dictionary<string, decimal> GetAllPrice()
        {

            try
            {
                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                MarketRequestModel list = OkAPi.SendRequestContent< MarketRequestModel> (ApiUrlList.API_Market);

                List<Ticker> l = list.tickers.FindAll(S => S.symbol.Contains("usdt"));

                foreach (var item in l)
                {
                    dic.Add(item.symbol, item.last);
                }


                return dic;
            }
            catch (Exception e)
            {
                Alert(e.ToString());

                return null;
            }
        }

        public override string GetExchangeName()
        {
            return "OkEx";
        }
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string symbol = ConvertSymbolTool.OKConvertSymbol(coin, currency);

            TicketRequset ticket= OkAPi.SendRequestContent<TicketRequset>(ApiUrlList.API_Ticker, symbol);

            if (ticket==null)
            {
                Alert("获取价格失败！");
                return 0;
            }

            return ticket.ticker.last;
        }
    }
}

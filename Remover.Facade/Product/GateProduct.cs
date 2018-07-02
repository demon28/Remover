using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Facade.GateAPI;
using Winner.Framework.Core.Facade;
using Remover.Entities.GateRequestModel;
using System.Collections;

namespace Remover.Facade
{
    public class GateProduct : ExChangeBase
    {

        private string Apikey, Seceretkey;
        GateAPIFacade gateAPI;


        public GateProduct(string apiKey, string seceretKey)
        {
            Apikey = apiKey;
            Seceretkey = seceretKey;

            gateAPI = new GateAPIFacade(Apikey, Seceretkey);
        }

        public override Dictionary<string, decimal> GetAllPrice()
        {


            try
            {

                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();

                var list = gateAPI.SendRequestContent<Dictionary<string, Btc_Usdt>>(ApiUrlList.API_Market);

                var l = list.Where(S => S.Key.Contains("usdt"));

                foreach (var item in l)
                {
                    dic.Add(item.Key, item.Value.last);
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
            return "GateIO";
        }

        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.GateConvertSymbol(coin, currency);

            var result = gateAPI.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result.last == 0)
            {
                return 0;
            }

            return result.last;
        }
    }
}

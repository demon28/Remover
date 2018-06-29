using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Facade.CoinealAPI;
using Remover.Entities.CoinealRequestModel;

namespace Remover.Facade.Product
{
    public class CoinealProduct : ExChangeBase
    {

        private string Apikey, Seceretkey;
        CoinealAPIFacade coinealAPI;




        public CoinealProduct(string apiKey, string seceretKey)
        {
            Apikey = apiKey;
            Seceretkey = seceretKey;

            coinealAPI = new CoinealAPIFacade(Apikey, Seceretkey);
        }

        public override Dictionary<string, decimal> GetAllPrice()
        {

            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();

            MarketRequest marketRequest= coinealAPI.EnSendRequestContent<MarketRequest>(ApiUrlList.API_Market);

            var l  = marketRequest.data.Where(S => S.Key.Contains("usdt")).ToDictionary(S=>S.Key,S=>S.Value);


            foreach (var item in l)
            {

                if (item.Key.Length == 7)
                {
                    dic.Add(item.Key.Insert(3, "_"),item.Value);
                }
                else if (item.Key.Length == 8)
                {
                    dic.Add(item.Key.Insert(4, "_"), item.Value);
                }
                else
                {
                    dic.Add(item.Key.Insert(5, "_"), item.Value);
                }

            }


            return dic;

        }

        public override string GetExchangeName()
        {
            return "Conieal";
        }

        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.HBConvertSymbol(coin, currency);

            var result = coinealAPI.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result.data.buy <= 0)
            {
                return 0;
            }

            return result.data.buy;
        }
    }
}

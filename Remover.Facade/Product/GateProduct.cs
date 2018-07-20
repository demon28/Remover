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
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

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

        protected override Dictionary<string, decimal> GetAllPrice()
        {


            try
            {

                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                Log.Info("START GET GateProduct:" + GetExchangeName());
                var list = gateAPI.SendRequestContent<Dictionary<string, Btc_Usdt>>(ApiUrlList.API_Market);
                Log.Info("End GET GateProduct:" + GetExchangeName());
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

        public override decimal GetSingleNowPrice(CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.GateConvertSymbol(coin, currency);

            var result = gateAPI.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result.last == 0 || result == null )
            {
                return 0;
            }

            return result.last;
        }

        public override BasePriceModel GetNowPrice(string coin, string currency)
        {
            BasePriceModel basePrice = new BasePriceModel();
            string Symbol = ConvertSymbolTool.GateConvertSymbol(coin, currency);
            var result = gateAPI.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);
            if (result == null)
            {
                Log.Error("GATE数据为空" + coin);
                return basePrice;
            }
            basePrice.buyPrice = result.highestBid;
            basePrice.sellPice = result.lowestAsk;
            basePrice.price = result.last;
            return basePrice;
        }

        public override LatePriceModel GetLatestRecord(string coin, string currency)
        {
            LatePriceModel latePrice = new LatePriceModel();
            string Symbol = ConvertSymbolTool.GateConvertSymbol(coin, currency);
            var result = gateAPI.SendRequestContent<DepthRequest>(ApiUrlList.API_OrderBooks, Symbol);
            if (result == null)
            {
                Log.Error("GATE数据为空" + coin);
                return latePrice;
            }

            List<PriceModel> asksList = new List<PriceModel>();
            foreach (var asksPrice in result.asks)
            {
                PriceModel asks = new PriceModel();
                asks.price = asksPrice[0];
                asks.amount = asksPrice[1];
                asksList.Add(asks);
            }

            List<PriceModel> bidsList = new List<PriceModel>();
            foreach (var bidsPrice in result.bids)
            {
                PriceModel bids = new PriceModel();
                bids.price = bidsPrice[0];
                bids.amount = bidsPrice[1];
                bidsList.Add(bids);
            }

            latePrice.Asks = asksList;
            latePrice.Bids = bidsList;
            return latePrice;
        }

    }
}

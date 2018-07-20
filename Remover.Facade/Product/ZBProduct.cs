using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Entities.ZBRequsetModel;
using Remover.Facade.ZBAPI;
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

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

        protected override Dictionary<string, decimal> GetAllPrice()
        {

            try
                {
                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                Log.Info("START GET ZBProduct:" + GetExchangeName());
                var list = api.SendRequestContent<Dictionary<string, Hpybtc>>(ApiUrlList.API_Market);
                Log.Info("End GET ZBProduct:" + GetExchangeName());
                var l = list.Where(S => S.Key.Contains("usdt"));

                foreach (var item in l)
                {

                    var key = string.Empty;

                    if (item.Key.Length == 7)
                    {
                        key = item.Key.Insert(3, "_");
                    }
                    else if (item.Key.Length == 8)
                    {
                        key = item.Key.Insert(4, "_");
                    }
                    else
                    {
                        key = item.Key.Insert(5, "_");
                    }
                    key = key.ToLower();

                    dic.Add(key, item.Value.last);
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
            return "ZB(中币)";
        }

        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.ZBConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result==null)
            {
                return 0;
            }

            return result.ticker.last;
        }

        public override BasePriceModel GetNowPrice(string coin, string currency)
        {
            BasePriceModel basePrice = new BasePriceModel();
            string Symbol = ConvertSymbolTool.ZBConvertSymbol(coin, currency);
            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);
            if (result == null)
            {
                Log.Error("ZB数据为空" + coin);
                return basePrice;
            }
            basePrice.buyPrice = result.ticker.buy;
            basePrice.sellPice = result.ticker.sell;
            basePrice.price = result.ticker.last;
            return basePrice;
        }

        public override LatePriceModel GetLatestRecord(string coin, string currency)
        {
            LatePriceModel latePrice = new LatePriceModel();
            string Symbol = ConvertSymbolTool.ZBConvertSymbol(coin, currency);
            var result = api.SendRequestContent<DepthRequest>(ApiUrlList.API_Depth, Symbol);

            if (result == null)
            {
                Log.Error("ZB数据为空" + coin);
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

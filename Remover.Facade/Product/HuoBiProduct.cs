using Remover.Entities;
using Remover.Facade.HuoBiAPI;
using Remover.Entities.HBRequestModel;
using System.Collections.Generic;
using System;
using System.Collections;
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{

    /// <summary>
    /// 火币实例
    /// </summary>
    internal class HuoBiProduct : ExChangeBase
    {


        private string AccessKey, SeceretKey;

        HuoBiApiFacade api;

        public HuoBiProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new HuoBiApiFacade(AccessKey, SeceretKey);
        }


        protected override Dictionary<string, decimal> GetAllPrice()
        {
            try
            {
                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                Log.Info("START GET HuoBiProduct:" + GetExchangeName());
                MarketRequestModel list = api.SendRequestContent<MarketRequestModel>(ApiUrlList.API_Market);
                Log.Info("End GET HuoBiProduct:" + GetExchangeName());
                List<Datum> l = list.data.FindAll(S => S.symbol.Contains("usdt"));

                foreach (var item in l)
                {
                    if (item.symbol.Length == 7)
                    {
                        item.symbol = item.symbol.Insert(3, "_");
                    }
                    else if (item.symbol.Length == 8)
                    {
                        item.symbol = item.symbol.Insert(4, "_");
                    }
                    else
                    {
                        item.symbol = item.symbol.Insert(5, "_");
                    }
                    item.symbol = item.symbol.ToLower();

                    dic.Add(item.symbol, item.low);


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
            return "火币";
        }



        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {

            try
            {
                string Symbol = ConvertSymbolTool.HBConvertSymbol(coin, currency);

                var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

                if (result==null|| result.tick.ask.Length <= 0 )
                {
                    return 0;
                }

                return decimal.Parse(result.tick.ask[0].ToString("f3"));
            }
            catch
            {
                return 0;
            }
        }

        public override BasePriceModel GetNowPrice(string coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            BasePriceModel basePrice = new BasePriceModel();
            string Symbol = ConvertSymbolTool.HBConvertSymbol(coin, currency);
            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);
            if(result.status!="ok")
            {
                return basePrice;
            }
            if (result.tick == null)
            {
                Log.Error("HUOBI数据为空" + coin);
                return basePrice;
            }
            basePrice.buyPrice = result.tick.bid[0];
            basePrice.sellPice = result.tick.ask[0];
            basePrice.price = result.tick.close;
            return basePrice;
        }
    }
}

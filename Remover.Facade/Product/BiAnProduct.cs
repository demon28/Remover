using Remover.Entities;
using Remover.Entities.BiAnRequestModel;
using Remover.Facade.BiAnAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
    public class BiAnProduct : ExChangeBase
    {

        private string AccessKey, SeceretKey;

        BiAnAPIFacade api;

        public BiAnProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {
            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new BiAnAPIFacade(AccessKey, SeceretKey);
        }

        protected override Dictionary<string, decimal> GetAllPrice()
        {
            try
            {
                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                Log.Info("START GET BiAnProduct:" + GetExchangeName());
                List<TicketRequest> list = api.SendRequestContent<List<TicketRequest>>(ApiUrlList.API_Market);
                Log.Info("End GET BiAnProduct:" + GetExchangeName());
                List<TicketRequest> l = list.FindAll(S => S.symbol.Contains("USDT"));
                
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
                    dic.Add(item.symbol, item.lastPrice);
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
            return "币安";
        }

        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.BiAnConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);
            
            if (result.lastPrice <= 0)
            {
                return 0;
            }

            return result.lastPrice;

        }

        public override BasePriceModel GetNowPrice(string coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            BasePriceModel basePrice = new BasePriceModel();
            string Symbol = ConvertSymbolTool.BiAnConvertSymbol(coin, currency);
            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);
            basePrice.buyPrice = result.bidPrice;
            basePrice.sellPice = result.askPrice;
            basePrice.price = result.lastPrice;
            return basePrice;
        }

    }
}

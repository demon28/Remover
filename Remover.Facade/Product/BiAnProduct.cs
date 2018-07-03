using Remover.Entities;
using Remover.Entities.BiAnRequestModel;
using Remover.Facade.BiAnAPI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Remover.Facade
{
    public class BiAnProduct:ExChangeBase
    {

        private string AccessKey, SeceretKey;

        BiAnAPIFacade api;

        public BiAnProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new BiAnAPIFacade(AccessKey, SeceretKey);
        }

        public override Dictionary<string,decimal> GetAllPrice() 
        {

            
            try {

             Dictionary<string, decimal> dic = new Dictionary<string, decimal>();

            List<TicketRequest> list = api.SendRequestContent<List<TicketRequest>>(ApiUrlList.API_Market);

            List<TicketRequest> l=list.FindAll(S => S.symbol.Contains("USDT"));

            
            foreach (var item in l)
            {
                if (item.symbol.Length == 7)
                {
                    item.symbol = item.symbol.Insert(3, "_");
                }
                else if(item.symbol.Length == 8)
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
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency=EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.BiAnConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result == null||result.lastPrice<= 0)
            {
                return 0;
            }

            return result.lastPrice;

        }

        
    }
}

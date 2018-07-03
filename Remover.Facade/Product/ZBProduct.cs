﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;
using Remover.Entities.ZBRequsetModel;
using Remover.Facade.ZBAPI;

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

        public override Dictionary<string, decimal> GetAllPrice()
        {

            try
                {
                Dictionary<string, decimal> dic = new Dictionary<string, decimal>();

                var list = api.SendRequestContent<Dictionary<string, Hpybtc>>(ApiUrlList.API_Market);

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
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.ZBConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result==null)
            {
                return 0;
            }

            return result.ticker.last;

        }

      
    }
}

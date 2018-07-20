using Remover.DataAccess;
using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

namespace Remover.Facade.Service
{
    public class AddQuotes
    {
        public void TaskExecution(int platformId, int coinId,int exchangeId,string exName, string platformCode, string coinCode)
        {
            Log.Info("执行TaskExecution：" + platformCode + "_" + coinCode + "_"+ exName);
            try
            {
                ExchangeType eType = (ExchangeType)Enum.Parse(typeof(ExchangeType), platformCode);
                ExChangeBase eb = ExchangeFactory.InstanExchange(eType);
                BasePriceModel priceModel = eb.GetNowPrice(coinCode, exName);
                if(priceModel==null)
                {
                    return;
                }
                //得到1970年的时间戳
                DateTime timeStamp = new DateTime(1970, 1, 1);
                //注意这里有时区问题，用now就要减掉8个小时
                string timestamps = Convert.ToString((DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000);
                InsertQuotes(platformId, coinId, exchangeId, platformCode, coinCode, timestamps, priceModel);
                
                GC.Collect();
            }
            catch (Exception ex)
            {
                Log.Error("执行查询插入数据出错" + ex);
            }
        }

        private void InsertQuotes(int platformId, int coinId, int exchangeId, string platformCode, string coinCode, string timestamps, BasePriceModel priceModel)
        {
            Tmp_Quotes quotes = new Tmp_Quotes();
            quotes.CoinName = coinCode;
            quotes.Market = platformCode + "_" + coinCode;
            quotes.Price = priceModel.price;
            quotes.Buyprice = priceModel.buyPrice;
            quotes.Sellprice = priceModel.sellPice;
            quotes.PlatformId = platformId;
            quotes.CoinId = coinId;
            quotes.Timestamps = timestamps;
            quotes.Currencytype = (int)CurrencyType.USDT;
            quotes.CreateTime = DateTime.Now;
            if (!quotes.Insert())
            {
                Log.Error("新增数据失败"+ quotes.Market);
            }
        }
    }
}

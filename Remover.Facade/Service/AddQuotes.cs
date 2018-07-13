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
        public void TaskExecution(int platformId, int coinId, string platformCode, string coinCode)
        {
            //该平台没有此币，在此过滤
            if(platformCode=="ZB"&&coinCode== "TRX")
            {
                return;
            }
            Log.Info("执行TaskExecution：" + platformCode + "_" + coinCode);
            try
            {
                ExchangeType eType = (ExchangeType)Enum.Parse(typeof(ExchangeType), platformCode);
                ExChangeBase eb = ExchangeFactory.InstanExchange(eType);
                BasePriceModel priceModel = eb.GetNowPrice(coinCode, CurrencyType.USDT);
                if(priceModel==null)
                {
                    priceModel.price = 0m;
                    priceModel.sellPice = 0m;
                    priceModel.buyPrice = 0m;
                }
                Tr_Quotes quotes = new Tr_Quotes();
                quotes.CoinName = coinCode;
                quotes.Market = platformCode + "_" + coinCode;
                quotes.Price = priceModel.price;
                quotes.Buyprice = priceModel.buyPrice;
                quotes.Sellprice = priceModel.sellPice;
                quotes.PlatformId = platformId;
                quotes.CoinId = coinId;
                //得到1970年的时间戳
                DateTime timeStamp = new DateTime(1970, 1, 1);
                //注意这里有时区问题，用now就要减掉8个小时
                quotes.Timestamps = Convert.ToString((DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000);
                quotes.Currencytype = (int)CurrencyType.USDT;
                quotes.CreateTime = DateTime.Now;
                if (!quotes.Insert())
                {
                    Log.Error("新增数据失败");
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Log.Error("执行查询插入数据出错" + ex);
            }
        }
    }
}

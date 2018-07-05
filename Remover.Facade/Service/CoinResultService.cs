using Remover.DataAccess;
using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Job.Master.Interface;
using static Remover.Entities.EnumType;

namespace Remover.Facade.Service
{
    /// <summary>
    /// 根据每个币返回币价格
    /// </summary>
    public class CoinResultService : FacadeBase, IJob
    {
        public bool RunGetCoinPrice()
        {
            Log.Info("-----------------开始执行RunGetCoinPrice-------------------");
            try
            {
                Tr_PlatformCollection platformColl = new Tr_PlatformCollection();
                if (!platformColl.ListBuyStatus())
                {
                    Log.Info("未查询到Platform");
                    return false;
                }

                Tr_CointypeCollection cointypeColl = new Tr_CointypeCollection();
                if (!cointypeColl.ListBuyStatus())
                {
                    Log.Info("未查询到Cointype");
                    return false;
                }
                List<Task> tasks = new List<Task>();

                //循环平台
                foreach (Tr_Platform item in platformColl)
                {
                    //循环插入币种
                    foreach (Tr_Cointype coin in cointypeColl)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            TaskExecution(item.PlatformId, coin.Cid, item.PlatformCode, coin.CoinCode);
                        }));
                    }
                }

                Task.WaitAll(tasks.ToArray());

                Log.Info("-----------------结束执行RunGetCoinPrice-------------------");
            }
            catch (Exception ex)
            {
                Log.Error("执行失败", ex);
                throw;
            }

            return true;
        }

        static void TaskExecution(int platformId,int coinId, string platformCode, string coinCode)
        {
            Log.Info("执行TaskExecution");
            ExchangeType eType = (ExchangeType)Enum.Parse(typeof(ExchangeType), platformCode);
            ExChangeBase eb = ExchangeFactory.InstanExchange(eType);
            BasePriceModel priceModel = eb.GetNowPrice(coinCode, CurrencyType.USDT);
            Tr_Quotes quotes = new Tr_Quotes();
            quotes.CoinName = coinCode;
            quotes.Market = platformCode + "_" + coinCode;
            quotes.Price = priceModel.price;
            quotes.Buyprice = priceModel.buyPrice;
            quotes.Sellprice = priceModel.sellPice;
            quotes.PlatformId = platformId;
            quotes.CoinId = coinId;
            quotes.Timestamps = DateTime.UtcNow.ToString();
            quotes.Currencytype = (int)CurrencyType.USDT;
            quotes.CreateTime = DateTime.Now ;
            if(!quotes.Insert())
            {
                Log.Error("新增数据失败");
            }
            Log.Info("完成执行TaskExecution");
        }
        
        public JobResult Run(DateTime runTime)
        {
            if (!RunGetCoinPrice())
            {
                return JobResult.FailResult("执行批量查询币价失败");
            }
            return JobResult.SuccessResult();
        }
    }
}

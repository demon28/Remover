using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Remover.DataAccess;
using static Remover.Entities.EnumType;
using Remover.Entities;

namespace Remover.Facade.Service
{
    public class AddLatePrice
    {
        public void TaskExecution(int platformId, string platformCode, int coinId, string coinCode, int currencyId, string currencyCode)
        {
            //Log.Info($"执行更新市场深度TaskExecution,platformCode={platformCode};coinCode={coinCode};currencyCode={currencyCode}");
            try
            {
                ExchangeType eType = (ExchangeType)Enum.Parse(typeof(ExchangeType), platformCode);
                ExChangeBase eb = ExchangeFactory.InstanExchange(eType);
                LatePriceModel priceModel = eb.GetLatestRecord(coinCode, currencyCode);
                if (priceModel.Asks == null)
                {
                    Log.Error($"执行查询集合为空,platformCode={platformCode};coinCode={coinCode};currencyCode={currencyCode}");
                    return;
                }

                int PairId = InsertCurrencyPair(coinId, currencyId);
                //查询交易对是否存在
                InsertLatestRecord(platformId, PairId, priceModel);
                GC.Collect();
            }
            catch (Exception ex)
            {
                Log.Error("执行查询插入数据出错" + ex);
            }
        }

        public int InsertCurrencyPair(int coinId, int currencyId)
        {
            Tmp_Currency_Pair CurrencyPair = new Tmp_Currency_Pair();
            if (!CurrencyPair.GetByCoinIdAndExchangeId(coinId, currencyId))
            {
                return 0;
            }
            return CurrencyPair.PairId;
        }

        private void InsertLatestRecord(int platformId, int pairId, LatePriceModel priceModel)
        {
            //Log.Info($"执行InsertLatestRecord:{platformId}_{pairId}");
            Tmp_Late_PriceCollection latestPriceColl = new Tmp_Late_PriceCollection();
            if (!latestPriceColl.DelByPlatform(platformId, pairId))
            {
                Log.Error("删除交易信息失败" + platformId + "_" + pairId);
            }

            int askscount = priceModel.Asks.Count;
            int bidscount = priceModel.Bids.Count;

            if (askscount < 5 || askscount <5)
                return;
            //int mincount = 0;
            //if (askscount <= bidscount)
            //    mincount = askscount;
            //else
            //    mincount = bidscount;

            //if (mincount == 0)
            //    return;

            List<PriceModel> ListAsks = priceModel.Asks.OrderBy(p => p.price).Take(5).ToList();
            List<PriceModel> ListBids = priceModel.Bids.OrderByDescending(p => p.price).Take(5).ToList();
            
            for (int i= 0; i<= 4; i++)
            {
                Tmp_Late_Price latePrice = new Tmp_Late_Price();
                latePrice.BuyPrice = ListBids[i].price;
                latePrice.BuyCount= ListBids[i].amount;
                latePrice.PairId = pairId;
                latePrice.SellPrice = ListAsks[i].price;
                latePrice.SellCount = ListAsks[i].amount;
                latePrice.Sort = i;
                latePrice.LateTime = DateTime.Now;
                latePrice.PlatformId = platformId;
                if (!latePrice.Insert())
                {
                    Log.Error("新增交易价格失败");
                    return;
                }
            }
            
            return;
        } 
    }
}


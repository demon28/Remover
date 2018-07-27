using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.DataAccess;
using Winner.Framework.Utils;

namespace Remover.Facade
{
    public class UpdateLatePriceFacade
    {
        /// <summary>
        /// 更新当前市场深度
        /// </summary>
        /// <param name="configModel">数据库配置Model</param>
        /// <param name="priceModel">市场深度MODEL</param>
        /// <returns></returns>
        public bool InsertLatestRecord(VmpConfigModel configModel, LatePriceModel priceModel)
        {
            //Log.Info($"执行InsertLatestRecord:{platformId}_{pairId}");
            Tmp_Late_Price tlatePrice = new Tmp_Late_Price();
            int isExisrence = tlatePrice.IsExistencePrice(configModel.PlatformId, configModel.PairId).Safe().ToInt32();
            if (isExisrence > 0)
            {
                Tmp_Late_PriceCollection latestPriceColl = new Tmp_Late_PriceCollection();
                if (!latestPriceColl.DelByPlatform(configModel.PlatformId, configModel.PairId))
                {
                    Log.Error("删除交易信息失败" + configModel.PairCode);
                }
            }

            int askscount = priceModel.Asks.Count;
            int bidscount = priceModel.Bids.Count;

            ///默认交易深度5条
            int specifiedQuantity = 5;

            if (bidscount < askscount || askscount < specifiedQuantity)
                return false;

            List<PriceModel> ListAsks = priceModel.Asks.OrderBy(p => p.price).Take(specifiedQuantity).ToList();
            List<PriceModel> ListBids = priceModel.Bids.OrderByDescending(p => p.price).Take(specifiedQuantity).ToList();

            for (int i = 0; i < specifiedQuantity; i++)
            {
                Tmp_Late_Price latePrice = new Tmp_Late_Price();
                latePrice.BuyPrice = ListBids[i].price;
                latePrice.BuyCount = ListBids[i].amount;
                latePrice.PairId = configModel.PairId; ;
                latePrice.SellPrice = ListAsks[i].price;
                latePrice.SellCount = ListAsks[i].amount;
                latePrice.Sort = i;
                latePrice.LateTime = DateTime.Now;
                latePrice.PlatformId = configModel.PlatformId;
                if (!latePrice.Insert())
                {
                    Log.Error("新增交易价格失败");
                    continue;
                }
            }
            //Log.Info($"执行完成InsertLatestRecord:{platformId}_{pairId}");
            return true;
        }
    }
}

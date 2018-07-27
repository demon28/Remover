using Remover.DataAccess;
using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Cache;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;

namespace Remover.Facade.Cache
{
    /// <summary>
    /// 更新缓存交易深度记录
    /// </summary>
    public class UpdateDepthFacade:FacadeBase
    {
        /// <summary>
        /// 更新缓存交易深度记录
        /// </summary>
        /// <param name="configModel">数据配置</param>
        /// <param name="priceModel">价格深度</param>
        /// <returns></returns>
        public bool UpdateLatePrice(VmpConfigModel configModel, LatePriceModel priceModel)
        {
            Log.Info($"更新市场深度缓存UpdateLatePrice:{configModel.PlatformCode}_{configModel.PairCode}");
            string cacheKey = string.Format("LatePrice_{0}_{1}", configModel.PlatformId, configModel.PairId);
            LatePriceCacheBase priceCache = InsertPrice(configModel, priceModel);
            var cache = CacheManage.GetInstance();
            if(!cache.Add(cacheKey, priceCache))
            {
                Alert("更新缓存失败");
                Log.Error("更新缓存失败" + cacheKey);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 装载MODEL
        /// </summary>
        /// <param name="configModel"></param>
        /// <param name="priceModel"></param>
        /// <returns></returns>
        private LatePriceCacheBase InsertPrice(VmpConfigModel configModel, LatePriceModel priceModel)
        {
            ///默认交易深度50条
            int specifiedQuantity = 50;
            int askscount = priceModel.Asks.Count;
            int bidscount = priceModel.Bids.Count;
            if (askscount > specifiedQuantity)
                askscount= specifiedQuantity;
            if (bidscount > specifiedQuantity)
                askscount = specifiedQuantity;

            List<PriceModel> ListAsks = priceModel.Asks.OrderBy(p => p.price).Take(specifiedQuantity).ToList();
            List<PriceModel> ListBids = priceModel.Bids.OrderByDescending(p => p.price).Take(specifiedQuantity).ToList();
            
            List<TickModel> bidTick = new List<TickModel>();
            for (int i = 0; i < bidscount; i++)
            {
                TickModel bidMode = new TickModel();
                bidMode.Amount = ListBids[i].amount;
                bidMode.Price = ListBids[i].price;
                bidMode.Sort = i;
                bidTick.Add(bidMode);
            }

            List<TickModel> askTick = new List<TickModel>();
            for(int k=0;k< askscount;k++)
            {
                TickModel askModel = new TickModel();
                askModel.Amount = ListAsks[k].amount;
                askModel.Price = ListAsks[k].price;
                askModel.Sort = k;
                askTick.Add(askModel);
            }
            LatePriceCacheBase priceCache = new LatePriceCacheBase();
            LatePriceCacheBase tempPrice = MapProvider.Map(priceCache, configModel);

            tempPrice.LateTime = DateTime.Now;
            tempPrice.BuyPrice = ListBids.FirstOrDefault().price;
            tempPrice.BuyCount = ListBids.FirstOrDefault().amount;
            tempPrice.SellPrice = ListAsks.FirstOrDefault().price;
            tempPrice.SellCount = ListAsks.FirstOrDefault().amount;
            tempPrice.Asks = askTick;
            tempPrice.Bids = bidTick;

            return tempPrice;
        }
    }
}

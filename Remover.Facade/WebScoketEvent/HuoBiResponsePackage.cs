using Newtonsoft.Json;
using Remover.DataAccess;
using Remover.Entities;
using Remover.Entities.HBRequestModel;
using Remover.Facade.Cache;
using Remover.Facade.WebSocketAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Remover.Facade.WebScoketEvent
{
    /// <summary>
    /// 事件内容
    /// </summary>
    public class HuoBiResponsePackage
    { 
        /// <summary>
        /// 处理火币返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public void MsgPackage(string message)
        {
            try
            {
                //Log.Info("接收消息2"+message);
                int index = message.IndexOf("subbed");
                if (index >= 0)
                {
                    Log.Info("调用火币监听成功:" + message);
                    return;
                }

                DepthWSRequest depth = JsonConvert.DeserializeObject<DepthWSRequest>(message);
                //查询所属平台及交易对
                string pairMark = StringProcess.HuoBiStringSplit(depth.ch);

                VpmConfigCache vpmConfigCache = new VpmConfigCache();
                List<VmpConfigModel> listModel = vpmConfigCache.ListConfig();
                var model = listModel.Where(p => p.PlatformCode.Equals("HuoBi") && p.Mark.Equals(pairMark)).FirstOrDefault(); 

                /*此处用于取数据库数据，最新的改为取缓存*/
                //Vmp_Config vmp_Config = new Vmp_Config();
                //if (!vmp_Config.GetByPlatformPair("HuoBi", pairMark))
                //{
                //    Log.Error("未找到相应的配置:"+ pairMark);
                //    return;
                //}
                //var model = MapProvider.Map<VmpConfigModel>(vmp_Config.DataRow);

                List<PriceModel> asksList = new List<PriceModel>();
                foreach (var asksPrice in depth.tick.asks)
                {
                    PriceModel asks = new PriceModel();
                    asks.price = asksPrice[0];
                    asks.amount = asksPrice[1];
                    asksList.Add(asks);
                }

                List<PriceModel> bidsList = new List<PriceModel>();
                foreach (var bidsPrice in depth.tick.bids)
                {
                    PriceModel bids = new PriceModel();
                    bids.price = bidsPrice[0];
                    bids.amount = bidsPrice[1];
                    bidsList.Add(bids);
                }
                LatePriceModel latePrice = new LatePriceModel();
                latePrice.Asks = asksList;
                latePrice.Bids = bidsList;

                //更新数据库市场深度
                //UpdateLatePriceFacade latePriceFacade =new UpdateLatePriceFacade();
                //latePriceFacade.InsertLatestRecord(model, latePrice);
                //更新缓存市场深度
                UpdateDepthFacade depthFacade = new UpdateDepthFacade();
                if (!depthFacade.UpdateLatePrice(model, latePrice))
                {
                    Log.Error($"Error,更新缓存市场深度失败,platformCode={model.PlatformCode};coinCode={model.CurrencyCode};currencyCode={model.ExCurrencyCode}");
                }
            }
            catch (Exception ex)
            {
                Log.Error("更新市场深度失败：" + ex);
            }
        }
    }
}

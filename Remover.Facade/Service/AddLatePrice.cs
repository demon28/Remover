using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Remover.DataAccess;
using static Remover.Entities.EnumType;
using Remover.Entities;
using Remover.Facade.Cache;

namespace Remover.Facade.Service
{
    public class AddLatePrice
    {
        /// <summary>
        /// 执行TASK更新市场深度
        /// </summary>
        /// <param name="model"></param>
        public void TaskExecution(VmpConfigModel model)
        {
            //Log.Info($"执行更新市场深度TaskExecution,platformCode={platformCode};coinCode={coinCode};currencyCode={currencyCode}");
            try
            {
                ExchangeType eType = (ExchangeType)Enum.Parse(typeof(ExchangeType), model.PlatformCode);
                ExChangeBase eb = ExchangeFactory.InstanExchange(eType);
                LatePriceModel priceModel = eb.GetLatestRecord(model.CurrencyCode, model.ExCurrencyCode);
                if (priceModel.Asks == null)
                {
                    Log.Error($"执行查询集合为空,platformCode={model.PlatformCode};coinCode={model.CurrencyCode};currencyCode={model.ExCurrencyCode}");
                    return;
                }

                //更新数据库市场深度
                //UpdateLatePriceFacade latePriceFacade =new UpdateLatePriceFacade();
                //latePriceFacade.InsertLatestRecord(model, priceModel);
                //更新缓存市场深度
                UpdateDepthFacade depthFacade = new UpdateDepthFacade();
                if(!depthFacade.UpdateLatePrice(model, priceModel))
                {
                    Log.Error($"Error,更新缓存市场深度失败,platformCode={model.PlatformCode};coinCode={model.CurrencyCode};currencyCode={model.ExCurrencyCode}");
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


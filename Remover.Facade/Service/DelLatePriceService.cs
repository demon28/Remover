using Remover.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using Winner.Job.Master.Interface;

namespace Remover.Facade.Service
{
    public class DelLatePriceService : FacadeBase, IJob
    {
        /// <summary>
        /// 删除5分钟内未更新的数据
        /// </summary>
        /// <returns></returns>
        public bool RunDelLatePrice()
        {
            Log.Info("-----------------开始执行RunDelLatePrice-------------------");
            try
            {
                Tmp_Late_PriceCollection latePrice = new Tmp_Late_PriceCollection();
                if (!latePrice.DelByTime())
                {
                    Log.Info("执行删除失败,没有可删除数据");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("执行失败", ex);
                throw;
            }
            Log.Info("-----------------结束执行RunDelLatePrice-------------------");
            return true;
        }

        public JobResult Run(DateTime runTime)
        {
            if (!RunDelLatePrice())
            {
                return JobResult.FailResult("执行批量删除超时市场深度失败");
            }
            return JobResult.SuccessResult();
        }
    }
}

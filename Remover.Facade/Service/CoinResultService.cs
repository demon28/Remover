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
                Vmp_ConfigCollection coinCoinfig = new Vmp_ConfigCollection();
                if (!coinCoinfig.ListCoinfig())
                {
                    Log.Info("未查询到coinCoinfig");
                    return false;
                }
                
                List<Task> tasks = new List<Task>();

                //循环平台
                foreach (Vmp_Config item in coinCoinfig)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        AddQuotes jobServcie = new AddQuotes();
                        jobServcie.TaskExecution(item.PlatformId, item.CurrencyId, item.ExCurrencyId, item.ExCurrencyCode, item.PlatformCode, item.CurrencyCode);
                    }));
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error("执行失败", ex);
                throw;
            }
            Log.Info("-----------------结束执行RunGetCoinPrice-------------------");
            return true;
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

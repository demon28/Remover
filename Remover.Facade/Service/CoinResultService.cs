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
                if (!coinCoinfig.ListByPlatformCode("Coin"))
                {
                    Log.Info("未查询到coinCoinfig");
                    return false;
                }
                List<VmpConfigModel> list = new List<VmpConfigModel>();
                list = MapProvider.Map<VmpConfigModel>(coinCoinfig.DataTable);

                List<Task> tasks = new List<Task>();

                //循环配置表
                foreach (VmpConfigModel item in list)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        AddLatePrice jobServcie = new AddLatePrice();
                        jobServcie.TaskExecution(item);
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

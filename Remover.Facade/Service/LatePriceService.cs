using Remover.DataAccess;
using Remover.Entities;
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
    public class LatePriceService : FacadeBase, IJob
    {
        /// <summary>
        /// 查询所有平台交易对，更新市场深度
        /// </summary>
        /// <returns></returns>
        public bool RunGetLatestRecord()
        {
            Log.Info("-----------------开始执行RunGetLatestRecord-------------------");
            try
            {
                Vmp_ConfigCollection coinfig = new Vmp_ConfigCollection();
                if (!coinfig.ListCoinfig())
                {
                    Log.Info("未查询到coinfig");
                    return false;
                }
                List<VmpConfigModel> list = new List<VmpConfigModel>();
                list = MapProvider.Map<VmpConfigModel>(coinfig.DataTable);

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
            Log.Info("-----------------结束执行RunGetLatestRecord-------------------");
            return true;
        }

        public JobResult Run(DateTime runTime)
        {
            if (!RunGetLatestRecord())
            {
                return JobResult.FailResult("执行批量查询市场深度失败");
            }
            return JobResult.SuccessResult();
        }
    }
}

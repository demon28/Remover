﻿using Remover.DataAccess;
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
    public class HuoBiDepthService : FacadeBase, IJob
    {
        public bool RunHuoBiDepthService()
        {
            Log.Info("-----------------开始执行RunHuoBiDepthService-------------------");
            try
            {
                Vmp_ConfigCollection coinfig = new Vmp_ConfigCollection();
                if (!coinfig.ListByPlatformCode("HuoBi"))
                {
                    Log.Info("未查询到coinfig");
                    return false;
                }

                List<Task> tasks = new List<Task>();

                //循环平台
                foreach (Vmp_Config item in coinfig)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        AddLatePrice jobServcie = new AddLatePrice();
                        jobServcie.TaskExecution(item.PlatformId, item.PlatformCode, item.CurrencyId, item.CurrencyCode, item.ExCurrencyId, item.ExCurrencyCode);
                    }));
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error("执行失败", ex);
                throw;
            }
            Log.Info("-----------------结束执行RunHuoBiDepthService-------------------");
            return true;
        }

        public JobResult Run(DateTime runTime)
        {
            if (!RunHuoBiDepthService())
            {
                return JobResult.FailResult("执行批量查询市场深度失败");
            }
            return JobResult.SuccessResult();
        }
    }
}

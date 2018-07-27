/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Late_Price.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-17 18:17:01  
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.MySql;
using Winner.Framework.Utils;
using Remover.Entities;
namespace Remover.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tmp_Late_Price
    /// </summary>
    public partial class Tmp_Late_Price : DataAccessBase
    {
        public int? IsExistencePrice(int platform, int pairId)
        {
            string sql= "select count(0) from tmp_late_price where platform_id=?platform and pair_id=?pairId";
            AddParameter("platform", platform);
            AddParameter("pairId", pairId);
            return GetIntValue(sql);
        }

        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Late_Price
    /// </summary>
    public partial class Tmp_Late_PriceCollection : DataAccessCollectionBase
    {
        public bool DelByPlatform(int platform,int pairId)
        {
            string sql = "delete from tmp_late_price where platform_id=?platform and pair_id=?pairId";
            AddParameter("platform", platform);
            AddParameter("pairId", pairId);
            return DeleteBySql(sql);
        }

        public bool DelByTime()
        {
            string sql = "delete From tmp_late_price where DATE(late_time) <= DATE(DATE_SUB(NOW(), INTERVAL 5 MINUTE))";
            return DeleteBySql(sql);
        }

        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 
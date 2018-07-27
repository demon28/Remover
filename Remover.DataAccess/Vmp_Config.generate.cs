/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Vmp_Config.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳乾海盛斯塔克科技有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-18 20:03:16  
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
namespace Remover.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Vmp_Config
    /// </summary>
    public partial class Vmp_Config : DataAccessBase
    {
        /// <summary>
        /// 根据平台名称和交易对获取
        /// </summary>
        /// <param name="platfromCode"></param>
        /// <param name="pairMark"></param>
        /// <returns></returns>
        public bool GetByPlatformPair(string platfromCode,string pairMark)
        {
            string sql= " platform_code =?platfromCode and mark =?pairMark";
            AddParameter("platfromCode", platfromCode);
            AddParameter("pairMark", pairMark);
            return SelectByCondition(sql);
        }
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Vmp_Config
    /// </summary>
    public partial class Vmp_ConfigCollection : DataAccessCollectionBase
    {
        public bool ListCoinfig()
        {
            string sql = "status=1";
            return ListByCondition(sql);
        }

        public bool ListByPlatformCode(string platformCode)
        {
            string sql = "platform_code=?platformCode and status=1";
            AddParameter("platformCode", platformCode);
            return ListByCondition(sql);
        }

        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 
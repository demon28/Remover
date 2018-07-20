/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tr_Exchange.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-06-16 10:31:35  
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
    /// Data Access Layer Object Of Tr_Exchange
    /// </summary>
    public partial class Tmp_Exchange : DataAccessBase
    {
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tr_Exchange
    /// </summary>
    public partial class Tmp_ExchangeCollection : DataAccessCollectionBase
    {
        public bool GetByStatus()
        {
            string sql = " status=1";
            return ListByCondition(sql);
        }

        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 
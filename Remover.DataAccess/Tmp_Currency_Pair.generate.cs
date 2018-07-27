/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Currency_Pair.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-17 21:37:25  
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
    /// Data Access Layer Object Of Tmp_Currency_Pair
    /// </summary>
    public partial class Tmp_Currency_Pair : DataAccessBase
    {
        public bool GetByCoinIdAndExchangeId(int coinId,int exchangeId)
        {
            string sql = " currency_id=?coinid and ex_currency_id=?exchangeId";
            AddParameter("coinid", coinId);
            AddParameter("exchangeId", exchangeId);
            return SelectByCondition(sql);
        }
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Currency_Pair
    /// </summary>
    public partial class Tmp_Currency_PairCollection : DataAccessCollectionBase
    {
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 
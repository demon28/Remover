﻿/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Exchange.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-18 20:10:22  
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
    /// Data Access Layer Object Of Tmp_Exchange
    /// </summary>
    public partial class Tmp_Exchange : DataAccessBase
    {
        #region 默认构造

        public Tmp_Exchange() : base() { }

        public Tmp_Exchange(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _eid="eid";
		public const string _ex_name="ex_name";
		public const string _createtime="createtime";
		public const string _status="status";
		public const string _remark="remark";

    
        public const string _TABLENAME="tmp_exchange";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Eid
		{
			get { return getProperty<int>(_eid); }
			set { setProperty(_eid,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string ExName
		{
			get { return getProperty<string>(_ex_name); }
			set { setProperty(_ex_name,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime
		{
			get { return getProperty<DateTime>(_createtime); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public int? Status
		{
			get { return getProperty<int?>(_status); }
			set { setProperty(_status,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Remark
		{
			get { return getProperty<string>(_remark); }
			set { setProperty(_remark,value); }
		}

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_eid, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ex_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_createtime, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tmp_exchange where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int eid)
        {
            string condition = "eid=?eid";
            AddParameter(_eid, eid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "eid=?eid";
            AddParameter(_eid, Eid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tmp_exchange(
  ex_name,
  status,
  remark)
values(
  ?ex_name,
  ?status,
  ?remark)";
			AddParameter(_ex_name,DataRow[_ex_name]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_remark,DataRow[_remark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Eid = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_eid);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tmp_exchange set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where eid=?eid");
            AddParameter(_eid, DataRow[_eid]);
            if (!string.IsNullOrEmpty(condition))
                sql.AppendLine(" and " + condition);
                
            bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
        }

        protected bool SelectByCondition(string condition)
        {
            string sql = @"
select
  eid,
  ex_name,
  createtime,
  status,
  remark
from tmp_exchange
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int eid)
        {
            string condition = "eid=?eid";
            AddParameter(_eid, eid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Exchange
    /// </summary>
    public partial class Tmp_ExchangeCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tmp_ExchangeCollection() { }

        public Tmp_ExchangeCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tmp_Exchange(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tmp_Exchange().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tmp_Exchange._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  eid,
  ex_name,
  createtime,
  status,
  remark
from tmp_exchange
where " + condition;
            return base.ListBySql(sql);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "delete from tmp_exchange where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tmp_Exchange this[int index]
        {
            get
            {
                return new Tmp_Exchange(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tmp_Exchange Find(Predicate<Tmp_Exchange> match)
        {
            foreach (Tmp_Exchange item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tmp_ExchangeCollection FindAll(Predicate<Tmp_Exchange> match)
        {
            Tmp_ExchangeCollection list = new Tmp_ExchangeCollection();
            foreach (Tmp_Exchange item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tmp_Exchange> match)
        {
            foreach (Tmp_Exchange item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tmp_Exchange> match)
        {
            BeginTransaction();
            foreach (Tmp_Exchange item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        #endregion Linq
        #endregion
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 
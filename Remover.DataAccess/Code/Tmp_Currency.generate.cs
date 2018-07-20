/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Currency.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-18 16:20:33  
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
    /// Data Access Layer Object Of Tmp_Currency
    /// </summary>
    public partial class Tmp_Currency : DataAccessBase
    {
        #region 默认构造

        public Tmp_Currency() : base() { }

        public Tmp_Currency(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _currency_id="currency_id";
		public const string _currency_name="currency_name";
		public const string _currency_code="currency_code";
		public const string _status="status";
		public const string _currency_logo="currency_logo";
		public const string _remarks="remarks";
		public const string _create_time="create_time";

    
        public const string _TABLENAME="tmp_currency";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int CurrencyId
		{
			get { return getProperty<int>(_currency_id); }
			set { setProperty(_currency_id,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string CurrencyName
		{
			get { return getProperty<string>(_currency_name); }
			set { setProperty(_currency_name,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string CurrencyCode
		{
			get { return getProperty<string>(_currency_code); }
			set { setProperty(_currency_code,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return getProperty<int>(_status); }
			set { setProperty(_status,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string CurrencyLogo
		{
			get { return getProperty<string>(_currency_logo); }
			set { setProperty(_currency_logo,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Remarks
		{
			get { return getProperty<string>(_remarks); }
			set { setProperty(_remarks,value); }
		}
		/// <summary>
		/// [default:new DateTime()]
		/// </summary>
		public DateTime CreateTime
		{
			get { return getProperty<DateTime>(_create_time); }
			set { setProperty(_create_time,value); }
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
			dt.Columns.Add(_currency_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_currency_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_currency_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_currency_logo, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_remarks, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_create_time, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tmp_currency where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int currencyId)
        {
            string condition = "currency_id=?currency_id";
            AddParameter(_currency_id, currencyId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "currency_id=?currency_id";
            AddParameter(_currency_id, CurrencyId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tmp_currency(
  currency_name,
  currency_code,
  status,
  currency_logo,
  remarks)
values(
  ?currency_name,
  ?currency_code,
  ?status,
  ?currency_logo,
  ?remarks)";
			AddParameter(_currency_name,DataRow[_currency_name]);
			AddParameter(_currency_code,DataRow[_currency_code]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_currency_logo,DataRow[_currency_logo]);
			AddParameter(_remarks,DataRow[_remarks]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			CurrencyId = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_currency_id);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tmp_currency set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where currency_id=?currency_id");
            AddParameter(_currency_id, DataRow[_currency_id]);
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
  currency_id,
  currency_name,
  currency_code,
  status,
  currency_logo,
  remarks,
  create_time
from tmp_currency
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int currencyId)
        {
            string condition = "currency_id=?currency_id";
            AddParameter(_currency_id, currencyId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Currency
    /// </summary>
    public partial class Tmp_CurrencyCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tmp_CurrencyCollection() { }

        public Tmp_CurrencyCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tmp_Currency(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tmp_Currency().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tmp_Currency._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  currency_id,
  currency_name,
  currency_code,
  status,
  currency_logo,
  remarks,
  create_time
from tmp_currency
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
            string sql = "delete from tmp_currency where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tmp_Currency this[int index]
        {
            get
            {
                return new Tmp_Currency(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tmp_Currency Find(Predicate<Tmp_Currency> match)
        {
            foreach (Tmp_Currency item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tmp_CurrencyCollection FindAll(Predicate<Tmp_Currency> match)
        {
            Tmp_CurrencyCollection list = new Tmp_CurrencyCollection();
            foreach (Tmp_Currency item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tmp_Currency> match)
        {
            foreach (Tmp_Currency item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tmp_Currency> match)
        {
            BeginTransaction();
            foreach (Tmp_Currency item in this)
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
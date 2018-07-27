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
* CreateTime : 2018-07-27 17:47:38  
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
        #region 默认构造

        public Vmp_Config() : base() { }

        public Vmp_Config(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _platform_id="platform_id";
		public const string _platform_code="platform_code";
		public const string _platform_name="platform_name";
		public const string _currency_id="currency_id";
		public const string _currency_code="currency_code";
		public const string _ex_currency_id="ex_currency_id";
		public const string _ex_currency_code="ex_currency_code";
		public const string _status="status";
		public const string _pair_id="pair_id";
		public const string _pair_code="pair_code";
		public const string _config_id="config_id";
		public const string _mark="mark";

    
        public const string _TABLENAME="vmp_config";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int PlatformId
		{
			get { return getProperty<int>(_platform_id); }
			set { setProperty(_platform_id,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string PlatformCode
		{
			get { return getProperty<string>(_platform_code); }
			set { setProperty(_platform_code,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string PlatformName
		{
			get { return getProperty<string>(_platform_name); }
			set { setProperty(_platform_name,value); }
		}
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
		public string CurrencyCode
		{
			get { return getProperty<string>(_currency_code); }
			set { setProperty(_currency_code,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int ExCurrencyId
		{
			get { return getProperty<int>(_ex_currency_id); }
			set { setProperty(_ex_currency_id,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string ExCurrencyCode
		{
			get { return getProperty<string>(_ex_currency_code); }
			set { setProperty(_ex_currency_code,value); }
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
		/// [default:0]
		/// </summary>
		public int PairId
		{
			get { return getProperty<int>(_pair_id); }
			set { setProperty(_pair_id,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string PairCode
		{
			get { return getProperty<string>(_pair_code); }
			set { setProperty(_pair_code,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int ConfigId
		{
			get { return getProperty<int>(_config_id); }
			set { setProperty(_config_id,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Mark
		{
			get { return getProperty<string>(_mark); }
			set { setProperty(_mark,value); }
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
			dt.Columns.Add(_platform_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_platform_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_platform_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_currency_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_currency_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_ex_currency_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ex_currency_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_pair_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_pair_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_config_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_mark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from VMP_CONFIG where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int platformId)
        {
            string condition = "platform_id=:platform_id";
            AddParameter(_platform_id, platformId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "platform_id=:platform_id";
            AddParameter(_platform_id, PlatformId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
vmp_config(
  platform_id,
  platform_code,
  platform_name,
  currency_id,
  currency_code,
  ex_currency_id,
  ex_currency_code,
  status,
  pair_id,
  pair_code,
  config_id,
  mark)
values(
  ?platform_id,
  ?platform_code,
  ?platform_name,
  ?currency_id,
  ?currency_code,
  ?ex_currency_id,
  ?ex_currency_code,
  ?status,
  ?pair_id,
  ?pair_code,
  ?config_id,
  ?mark)";
			AddParameter(_platform_id,DataRow[_platform_id]);
			AddParameter(_platform_code,DataRow[_platform_code]);
			AddParameter(_platform_name,DataRow[_platform_name]);
			AddParameter(_currency_id,DataRow[_currency_id]);
			AddParameter(_currency_code,DataRow[_currency_code]);
			AddParameter(_ex_currency_id,DataRow[_ex_currency_id]);
			AddParameter(_ex_currency_code,DataRow[_ex_currency_code]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_pair_id,DataRow[_pair_id]);
			AddParameter(_pair_code,DataRow[_pair_code]);
			AddParameter(_config_id,DataRow[_config_id]);
			AddParameter(_mark,DataRow[_mark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			PlatformId = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_platform_id);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update vmp_config set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where platform_id=:platform_id");
            AddParameter(_platform_id, DataRow[_platform_id]);
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
  platform_id,
  platform_code,
  platform_name,
  currency_id,
  currency_code,
  ex_currency_id,
  ex_currency_code,
  status,
  pair_id,
  pair_code,
  config_id,
  mark
from vmp_config
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int platformId)
        {
            string condition = "platform_id=:platform_id";
            AddParameter(_platform_id, platformId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Vmp_Config
    /// </summary>
    public partial class Vmp_ConfigCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Vmp_ConfigCollection() { }

        public Vmp_ConfigCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Vmp_Config(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Vmp_Config().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Vmp_Config._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  platform_id,
  platform_code,
  platform_name,
  currency_id,
  currency_code,
  ex_currency_id,
  ex_currency_code,
  status,
  pair_id,
  pair_code,
  config_id,
  mark
from vmp_config
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
            string sql = "delete from vmp_config where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Vmp_Config this[int index]
        {
            get
            {
                return new Vmp_Config(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Vmp_Config Find(Predicate<Vmp_Config> match)
        {
            foreach (Vmp_Config item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Vmp_ConfigCollection FindAll(Predicate<Vmp_Config> match)
        {
            Vmp_ConfigCollection list = new Vmp_ConfigCollection();
            foreach (Vmp_Config item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Vmp_Config> match)
        {
            foreach (Vmp_Config item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Vmp_Config> match)
        {
            BeginTransaction();
            foreach (Vmp_Config item in this)
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
/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Quotes.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-18 20:10:24  
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
    /// Data Access Layer Object Of Tmp_Quotes
    /// </summary>
    public partial class Tmp_Quotes : DataAccessBase
    {
        #region 默认构造

        public Tmp_Quotes() : base() { }

        public Tmp_Quotes(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _quotes_id="quotes_id";
		public const string _coin_id="coin_id";
		public const string _platform_id="platform_id";
		public const string _coin_name="coin_name";
		public const string _market="market";
		public const string _price="price";
		public const string _buyprice="buyprice";
		public const string _sellprice="sellprice";
		public const string _currencytype="currencytype";
		public const string _timestamps="timestamps";
		public const string _create_time="create_time";
		public const string _remark="remark";

    
        public const string _TABLENAME="tmp_quotes";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int QuotesId
		{
			get { return getProperty<int>(_quotes_id); }
			set { setProperty(_quotes_id,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int CoinId
		{
			get { return getProperty<int>(_coin_id); }
			set { setProperty(_coin_id,value); }
		}
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
		public string CoinName
		{
			get { return getProperty<string>(_coin_name); }
			set { setProperty(_coin_name,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Market
		{
			get { return getProperty<string>(_market); }
			set { setProperty(_market,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal Price
		{
			get { return getProperty<decimal>(_price); }
			set { setProperty(_price,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal Buyprice
		{
			get { return getProperty<decimal>(_buyprice); }
			set { setProperty(_buyprice,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal Sellprice
		{
			get { return getProperty<decimal>(_sellprice); }
			set { setProperty(_sellprice,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Currencytype
		{
			get { return getProperty<int>(_currencytype); }
			set { setProperty(_currencytype,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Timestamps
		{
			get { return getProperty<string>(_timestamps); }
			set { setProperty(_timestamps,value); }
		}
		/// <summary>
		/// [default:new DateTime()]
		/// </summary>
		public DateTime CreateTime
		{
			get { return getProperty<DateTime>(_create_time); }
			set { setProperty(_create_time,value); }
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
			dt.Columns.Add(_quotes_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_coin_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_platform_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_coin_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_market, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_price, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_buyprice, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_sellprice, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_currencytype, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_timestamps, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_create_time, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tmp_quotes where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int quotesId)
        {
            string condition = "quotes_id=?quotes_id";
            AddParameter(_quotes_id, quotesId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "quotes_id=?quotes_id";
            AddParameter(_quotes_id, QuotesId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tmp_quotes(
  coin_id,
  platform_id,
  coin_name,
  market,
  price,
  buyprice,
  sellprice,
  currencytype,
  timestamps,
  remark)
values(
  ?coin_id,
  ?platform_id,
  ?coin_name,
  ?market,
  ?price,
  ?buyprice,
  ?sellprice,
  ?currencytype,
  ?timestamps,
  ?remark)";
			AddParameter(_coin_id,DataRow[_coin_id]);
			AddParameter(_platform_id,DataRow[_platform_id]);
			AddParameter(_coin_name,DataRow[_coin_name]);
			AddParameter(_market,DataRow[_market]);
			AddParameter(_price,DataRow[_price]);
			AddParameter(_buyprice,DataRow[_buyprice]);
			AddParameter(_sellprice,DataRow[_sellprice]);
			AddParameter(_currencytype,DataRow[_currencytype]);
			AddParameter(_timestamps,DataRow[_timestamps]);
			AddParameter(_remark,DataRow[_remark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			QuotesId = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_quotes_id);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tmp_quotes set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where quotes_id=?quotes_id");
            AddParameter(_quotes_id, DataRow[_quotes_id]);
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
  quotes_id,
  coin_id,
  platform_id,
  coin_name,
  market,
  price,
  buyprice,
  sellprice,
  currencytype,
  timestamps,
  create_time,
  remark
from tmp_quotes
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int quotesId)
        {
            string condition = "quotes_id=?quotes_id";
            AddParameter(_quotes_id, quotesId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Quotes
    /// </summary>
    public partial class Tmp_QuotesCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tmp_QuotesCollection() { }

        public Tmp_QuotesCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tmp_Quotes(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tmp_Quotes().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tmp_Quotes._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  quotes_id,
  coin_id,
  platform_id,
  coin_name,
  market,
  price,
  buyprice,
  sellprice,
  currencytype,
  timestamps,
  create_time,
  remark
from tmp_quotes
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
            string sql = "delete from tmp_quotes where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tmp_Quotes this[int index]
        {
            get
            {
                return new Tmp_Quotes(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tmp_Quotes Find(Predicate<Tmp_Quotes> match)
        {
            foreach (Tmp_Quotes item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tmp_QuotesCollection FindAll(Predicate<Tmp_Quotes> match)
        {
            Tmp_QuotesCollection list = new Tmp_QuotesCollection();
            foreach (Tmp_Quotes item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tmp_Quotes> match)
        {
            foreach (Tmp_Quotes item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tmp_Quotes> match)
        {
            BeginTransaction();
            foreach (Tmp_Quotes item in this)
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
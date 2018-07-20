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
        #region 默认构造

        public Tmp_Late_Price() : base() { }

        public Tmp_Late_Price(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _id="id";
		public const string _platform_id="platform_id";
		public const string _pair_id="pair_id";
		public const string _buy_price="buy_price";
		public const string _buy_count="buy_count";
		public const string _sell_price="sell_price";
		public const string _sell_count="sell_count";
		public const string _sort="sort";
		public const string _late_time="late_time";
		public const string _remark="remark";
		public const string _create_time="create_time";

    
        public const string _TABLENAME="tmp_late_price";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Id
		{
			get { return getProperty<int>(_id); }
			set { setProperty(_id,value); }
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
		/// [default:0]
		/// </summary>
		public int PairId
		{
			get { return getProperty<int>(_pair_id); }
			set { setProperty(_pair_id,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal BuyPrice
		{
			get { return getProperty<decimal>(_buy_price); }
			set { setProperty(_buy_price,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal BuyCount
		{
			get { return getProperty<decimal>(_buy_count); }
			set { setProperty(_buy_count,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal SellPrice
		{
			get { return getProperty<decimal>(_sell_price); }
			set { setProperty(_sell_price,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal SellCount
		{
			get { return getProperty<decimal>(_sell_count); }
			set { setProperty(_sell_count,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Sort
		{
			get { return getProperty<int>(_sort); }
			set { setProperty(_sort,value); }
		}
		/// <summary>
		/// [default:new DateTime()]
		/// </summary>
		public DateTime LateTime
		{
			get { return getProperty<DateTime>(_late_time); }
			set { setProperty(_late_time,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Remark
		{
			get { return getProperty<string>(_remark); }
			set { setProperty(_remark,value); }
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
			dt.Columns.Add(_id, typeof(uint)).DefaultValue = 0;
			dt.Columns.Add(_platform_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_pair_id, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_buy_price, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_buy_count, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_sell_price, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_sell_count, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_sort, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_late_time, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_create_time, typeof(DateTime)).DefaultValue = new DateTime();

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tmp_late_price where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int id)
        {
            string condition = "id=?id";
            AddParameter(_id, id);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "id=?id";
            AddParameter(_id, Id);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tmp_late_price(
  platform_id,
  pair_id,
  buy_price,
  buy_count,
  sell_price,
  sell_count,
  sort,
  late_time,
  remark)
values(
  ?platform_id,
  ?pair_id,
  ?buy_price,
  ?buy_count,
  ?sell_price,
  ?sell_count,
  ?sort,
  ?late_time,
  ?remark)";
			AddParameter(_platform_id,DataRow[_platform_id]);
			AddParameter(_pair_id,DataRow[_pair_id]);
			AddParameter(_buy_price,DataRow[_buy_price]);
			AddParameter(_buy_count,DataRow[_buy_count]);
			AddParameter(_sell_price,DataRow[_sell_price]);
			AddParameter(_sell_count,DataRow[_sell_count]);
			AddParameter(_sort,DataRow[_sort]);
			AddParameter(_late_time,DataRow[_late_time]);
			AddParameter(_remark,DataRow[_remark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Id = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_id);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tmp_late_price set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where id=?id");
            AddParameter(_id, DataRow[_id]);
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
  id,
  platform_id,
  pair_id,
  buy_price,
  buy_count,
  sell_price,
  sell_count,
  sort,
  late_time,
  remark,
  create_time
from tmp_late_price
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int id)
        {
            string condition = "id=?id";
            AddParameter(_id, id);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Late_Price
    /// </summary>
    public partial class Tmp_Late_PriceCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tmp_Late_PriceCollection() { }

        public Tmp_Late_PriceCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tmp_Late_Price(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tmp_Late_Price().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tmp_Late_Price._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  id,
  platform_id,
  pair_id,
  buy_price,
  buy_count,
  sell_price,
  sell_count,
  sort,
  late_time,
  remark,
  create_time
from tmp_late_price
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
            string sql = "delete from tmp_late_price where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tmp_Late_Price this[int index]
        {
            get
            {
                return new Tmp_Late_Price(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tmp_Late_Price Find(Predicate<Tmp_Late_Price> match)
        {
            foreach (Tmp_Late_Price item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tmp_Late_PriceCollection FindAll(Predicate<Tmp_Late_Price> match)
        {
            Tmp_Late_PriceCollection list = new Tmp_Late_PriceCollection();
            foreach (Tmp_Late_Price item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tmp_Late_Price> match)
        {
            foreach (Tmp_Late_Price item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tmp_Late_Price> match)
        {
            BeginTransaction();
            foreach (Tmp_Late_Price item in this)
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
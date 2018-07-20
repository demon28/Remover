/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tmp_Order.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-18 20:10:21  
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
    /// Data Access Layer Object Of Tmp_Order
    /// </summary>
    public partial class Tmp_Order : DataAccessBase
    {
        #region 默认构造

        public Tmp_Order() : base() { }

        public Tmp_Order(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _orderid="orderid";
		public const string _orderno="orderno";
		public const string _outorderno="outorderno";
		public const string _rate="rate";
		public const string _amount="amount";
		public const string _status="status";
		public const string _create_time="create_time";
		public const string _remark="remark";
		public const string _buyorsell="buyorsell";
		public const string _user_id="user_id";
		public const string _market="market";
		public const string _currency="currency";
		public const string _coin_id="coin_id";

    
        public const string _TABLENAME="tmp_order";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Orderid
		{
			get { return getProperty<int>(_orderid); }
			set { setProperty(_orderid,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Orderno
		{
			get { return getProperty<string>(_orderno); }
			set { setProperty(_orderno,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Outorderno
		{
			get { return getProperty<string>(_outorderno); }
			set { setProperty(_outorderno,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal Rate
		{
			get { return getProperty<decimal>(_rate); }
			set { setProperty(_rate,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public decimal Amount
		{
			get { return getProperty<decimal>(_amount); }
			set { setProperty(_amount,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public uint Status
		{
			get { return getProperty<uint>(_status); }
			set { setProperty(_status,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? CreateTime
		{
			get { return getProperty<DateTime?>(_create_time); }
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
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Buyorsell
		{
			get { return getProperty<int>(_buyorsell); }
			set { setProperty(_buyorsell,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public uint? UserId
		{
			get { return getProperty<uint?>(_user_id); }
			set { setProperty(_user_id,value); }
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
		/// [default:DBNull.Value]
		/// </summary>
		public int? Currency
		{
			get { return getProperty<int?>(_currency); }
			set { setProperty(_currency,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public int? CoinId
		{
			get { return getProperty<int?>(_coin_id); }
			set { setProperty(_coin_id,value); }
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
			dt.Columns.Add(_orderid, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_orderno, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_outorderno, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_rate, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_amount, typeof(decimal)).DefaultValue = 0;
			dt.Columns.Add(_status, typeof(uint)).DefaultValue = 0;
			dt.Columns.Add(_create_time, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_buyorsell, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_user_id, typeof(uint)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_market, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_currency, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_coin_id, typeof(int)).DefaultValue = DBNull.Value;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tmp_order where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int orderid)
        {
            string condition = "orderid=?orderid";
            AddParameter(_orderid, orderid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "orderid=?orderid";
            AddParameter(_orderid, Orderid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tmp_order(
  orderno,
  outorderno,
  rate,
  amount,
  status,
  remark,
  buyorsell,
  user_id,
  market,
  currency,
  coin_id)
values(
  ?orderno,
  ?outorderno,
  ?rate,
  ?amount,
  ?status,
  ?remark,
  ?buyorsell,
  ?user_id,
  ?market,
  ?currency,
  ?coin_id)";
			AddParameter(_orderno,DataRow[_orderno]);
			AddParameter(_outorderno,DataRow[_outorderno]);
			AddParameter(_rate,DataRow[_rate]);
			AddParameter(_amount,DataRow[_amount]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_remark,DataRow[_remark]);
			AddParameter(_buyorsell,DataRow[_buyorsell]);
			AddParameter(_user_id,DataRow[_user_id]);
			AddParameter(_market,DataRow[_market]);
			AddParameter(_currency,DataRow[_currency]);
			AddParameter(_coin_id,DataRow[_coin_id]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Orderid = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_orderid);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tmp_order set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where orderid=?orderid");
            AddParameter(_orderid, DataRow[_orderid]);
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
  orderid,
  orderno,
  outorderno,
  rate,
  amount,
  status,
  create_time,
  remark,
  buyorsell,
  user_id,
  market,
  currency,
  coin_id
from tmp_order
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int orderid)
        {
            string condition = "orderid=?orderid";
            AddParameter(_orderid, orderid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tmp_Order
    /// </summary>
    public partial class Tmp_OrderCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tmp_OrderCollection() { }

        public Tmp_OrderCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tmp_Order(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tmp_Order().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tmp_Order._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  orderid,
  orderno,
  outorderno,
  rate,
  amount,
  status,
  create_time,
  remark,
  buyorsell,
  user_id,
  market,
  currency,
  coin_id
from tmp_order
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
            string sql = "delete from tmp_order where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tmp_Order this[int index]
        {
            get
            {
                return new Tmp_Order(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tmp_Order Find(Predicate<Tmp_Order> match)
        {
            foreach (Tmp_Order item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tmp_OrderCollection FindAll(Predicate<Tmp_Order> match)
        {
            Tmp_OrderCollection list = new Tmp_OrderCollection();
            foreach (Tmp_Order item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tmp_Order> match)
        {
            foreach (Tmp_Order item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tmp_Order> match)
        {
            BeginTransaction();
            foreach (Tmp_Order item in this)
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
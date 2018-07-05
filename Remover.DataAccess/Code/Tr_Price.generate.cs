/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tr_Price.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-06-16 10:31:34  
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
    /// Data Access Layer Object Of Tr_Price
    /// </summary>
    public partial class Tr_Price : DataAccessBase
    {
        #region 默认构造

        public Tr_Price() : base() { }

        public Tr_Price(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _pid="pid";
		public const string _eid="eid";
		public const string _cid="cid";
		public const string _price="price";
		public const string _createtime="createtime";
		public const string _remark="remark";

    
        public const string _TABLENAME="tr_price";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Pid
		{
			get { return getProperty<int>(_pid); }
			set { setProperty(_pid,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public int? Eid
		{
			get { return getProperty<int?>(_eid); }
			set { setProperty(_eid,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public int? Cid
		{
			get { return getProperty<int?>(_cid); }
			set { setProperty(_cid,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public decimal? Price
		{
			get { return getProperty<decimal?>(_price); }
			set { setProperty(_price,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Createtime
		{
			get { return getProperty<DateTime>(_createtime); }
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
			dt.Columns.Add(_pid, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_eid, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_cid, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_price, typeof(decimal)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_createtime, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tr_price where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int pid)
        {
            string condition = "pid=?pid";
            AddParameter(_pid, pid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "pid=?pid";
            AddParameter(_pid, Pid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tr_price(
  eid,
  cid,
  price,
  remark)
values(
  ?eid,
  ?cid,
  ?price,
  ?remark)";
			AddParameter(_eid,DataRow[_eid]);
			AddParameter(_cid,DataRow[_cid]);
			AddParameter(_price,DataRow[_price]);
			AddParameter(_remark,DataRow[_remark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Pid = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_pid);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tr_price set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where pid=?pid");
            AddParameter(_pid, DataRow[_pid]);
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
  pid,
  eid,
  cid,
  price,
  createtime,
  remark
from tr_price
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int pid)
        {
            string condition = "pid=?pid";
            AddParameter(_pid, pid);
            return SelectByCondition(condition);
        }
		public Tr_Cointype Get_Tr_Cointype_ByCid()
		{
			Tr_Cointype da=new Tr_Cointype();
			da.SelectByPK(Cid.Value);
			return da;
		}
		public Tr_Exchange Get_Tr_Exchange_ByEid()
		{
			Tr_Exchange da=new Tr_Exchange();
			da.SelectByPK(Eid.Value);
			return da;
		}



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tr_Price
    /// </summary>
    public partial class Tr_PriceCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tr_PriceCollection() { }

        public Tr_PriceCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tr_Price(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tr_Price().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tr_Price._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  pid,
  eid,
  cid,
  price,
  createtime,
  remark
from tr_price
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
            string sql = "delete from tr_price where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tr_Price this[int index]
        {
            get
            {
                return new Tr_Price(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tr_Price Find(Predicate<Tr_Price> match)
        {
            foreach (Tr_Price item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tr_PriceCollection FindAll(Predicate<Tr_Price> match)
        {
            Tr_PriceCollection list = new Tr_PriceCollection();
            foreach (Tr_Price item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tr_Price> match)
        {
            foreach (Tr_Price item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tr_Price> match)
        {
            BeginTransaction();
            foreach (Tr_Price item in this)
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
/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tr_Cointype.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-02 17:06:42  
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
    /// Data Access Layer Object Of Tr_Cointype
    /// </summary>
    public partial class Tr_Cointype : DataAccessBase
    {
        #region 默认构造

        public Tr_Cointype() : base() { }

        public Tr_Cointype(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _cid="cid";
		public const string _coin_name="coin_name";
		public const string _coin_logo="coin_logo";
		public const string _coin_code="coin_code";
		public const string _status="status";
		public const string _createtime="createtime";
		public const string _remark="remark";

    
        public const string _TABLENAME="tr_cointype";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Cid
		{
			get { return getProperty<int>(_cid); }
			set { setProperty(_cid,value); }
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
		public string CoinLogo
		{
			get { return getProperty<string>(_coin_logo); }
			set { setProperty(_coin_logo,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string CoinCode
		{
			get { return getProperty<string>(_coin_code); }
			set { setProperty(_coin_code,value); }
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
			dt.Columns.Add(_cid, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_coin_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_coin_logo, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_coin_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_createtime, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tr_cointype where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int cid)
        {
            string condition = "cid=?cid";
            AddParameter(_cid, cid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "cid=?cid";
            AddParameter(_cid, Cid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tr_cointype(
  coin_name,
  coin_logo,
  coin_code,
  status,
  remark)
values(
  ?coin_name,
  ?coin_logo,
  ?coin_code,
  ?status,
  ?remark)";
			AddParameter(_coin_name,DataRow[_coin_name]);
			AddParameter(_coin_logo,DataRow[_coin_logo]);
			AddParameter(_coin_code,DataRow[_coin_code]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_remark,DataRow[_remark]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Cid = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_cid);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tr_cointype set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where cid=?cid");
            AddParameter(_cid, DataRow[_cid]);
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
  cid,
  coin_name,
  coin_logo,
  coin_code,
  status,
  createtime,
  remark
from tr_cointype
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int cid)
        {
            string condition = "cid=?cid";
            AddParameter(_cid, cid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tr_Cointype
    /// </summary>
    public partial class Tr_CointypeCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tr_CointypeCollection() { }

        public Tr_CointypeCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tr_Cointype(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tr_Cointype().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tr_Cointype._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  cid,
  coin_name,
  coin_logo,
  coin_code,
  status,
  createtime,
  remark
from tr_cointype
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
            string sql = "delete from tr_cointype where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tr_Cointype this[int index]
        {
            get
            {
                return new Tr_Cointype(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tr_Cointype Find(Predicate<Tr_Cointype> match)
        {
            foreach (Tr_Cointype item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tr_CointypeCollection FindAll(Predicate<Tr_Cointype> match)
        {
            Tr_CointypeCollection list = new Tr_CointypeCollection();
            foreach (Tr_Cointype item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tr_Cointype> match)
        {
            foreach (Tr_Cointype item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tr_Cointype> match)
        {
            BeginTransaction();
            foreach (Tr_Cointype item in this)
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
/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsys_Winservice.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-02 16:32:55  
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
    /// Data Access Layer Object Of Tsys_Winservice
    /// </summary>
    public partial class Tsys_Winservice : DataAccessBase
    {
        #region 默认构造

        public Tsys_Winservice() : base() { }

        public Tsys_Winservice(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _winserviceid="winserviceid";
		public const string _servicename="servicename";
		public const string _cycle="cycle";
		public const string _nextruntime="nextruntime";
		public const string _status="status";
		public const string _iscontinue="iscontinue";
		public const string _createtime="createtime";
		public const string _queue="queue";
		public const string _typeconfig="typeconfig";
		public const string _remark="remark";
		public const string _retrytime="retrytime";
		public const string _retryinterval="retryinterval";

    
        public const string _TABLENAME="tsys_winservice";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Winserviceid
		{
			get { return getProperty<int>(_winserviceid); }
			set { setProperty(_winserviceid,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Servicename
		{
			get { return getProperty<string>(_servicename); }
			set { setProperty(_servicename,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Cycle
		{
			get { return getProperty<int>(_cycle); }
			set { setProperty(_cycle,value); }
		}
		/// <summary>
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Nextruntime
		{
			get { return getProperty<DateTime?>(_nextruntime); }
			set { setProperty(_nextruntime,value); }
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
		public int Iscontinue
		{
			get { return getProperty<int>(_iscontinue); }
			set { setProperty(_iscontinue,value); }
		}
		/// <summary>
		/// [default:new DateTime()]
		/// </summary>
		public DateTime Createtime
		{
			get { return getProperty<DateTime>(_createtime); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Queue
		{
			get { return getProperty<int>(_queue); }
			set { setProperty(_queue,value); }
		}
		/// <summary>
		/// [default:string.Empty]
		/// </summary>
		public string Typeconfig
		{
			get { return getProperty<string>(_typeconfig); }
			set { setProperty(_typeconfig,value); }
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
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? Retrytime
		{
			get { return getProperty<DateTime?>(_retrytime); }
			set { setProperty(_retrytime,value); }
		}
		/// <summary>
		/// [default:0]
		/// </summary>
		public int Retryinterval
		{
			get { return getProperty<int>(_retryinterval); }
			set { setProperty(_retryinterval,value); }
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
			dt.Columns.Add(_winserviceid, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_servicename, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_cycle, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_nextruntime, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_iscontinue, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_createtime, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_queue, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_typeconfig, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_retrytime, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_retryinterval, typeof(int)).DefaultValue = 0;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tsys_winservice where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int winserviceid)
        {
            string condition = "winserviceid=?winserviceid";
            AddParameter(_winserviceid, winserviceid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "winserviceid=?winserviceid";
            AddParameter(_winserviceid, Winserviceid);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tsys_winservice(
  servicename,
  cycle,
  nextruntime,
  status,
  iscontinue,
  queue,
  typeconfig,
  remark,
  retrytime,
  retryinterval)
values(
  ?servicename,
  ?cycle,
  ?nextruntime,
  ?status,
  ?iscontinue,
  ?queue,
  ?typeconfig,
  ?remark,
  ?retrytime,
  ?retryinterval)";
			AddParameter(_servicename,DataRow[_servicename]);
			AddParameter(_cycle,DataRow[_cycle]);
			AddParameter(_nextruntime,DataRow[_nextruntime]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_iscontinue,DataRow[_iscontinue]);
			AddParameter(_queue,DataRow[_queue]);
			AddParameter(_typeconfig,DataRow[_typeconfig]);
			AddParameter(_remark,DataRow[_remark]);
			AddParameter(_retrytime,DataRow[_retrytime]);
			AddParameter(_retryinterval,DataRow[_retryinterval]);
			int @id;
			bool result=InsertBySql(sql,out @id);
			Winserviceid = @id;
			return result;

        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_winserviceid);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update tsys_winservice set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where winserviceid=?winserviceid");
            AddParameter(_winserviceid, DataRow[_winserviceid]);
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
  winserviceid,
  servicename,
  cycle,
  nextruntime,
  status,
  iscontinue,
  createtime,
  queue,
  typeconfig,
  remark,
  retrytime,
  retryinterval
from tsys_winservice
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int winserviceid)
        {
            string condition = "winserviceid=?winserviceid";
            AddParameter(_winserviceid, winserviceid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tsys_Winservice
    /// </summary>
    public partial class Tsys_WinserviceCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsys_WinserviceCollection() { }

        public Tsys_WinserviceCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsys_Winservice(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsys_Winservice().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsys_Winservice._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  winserviceid,
  servicename,
  cycle,
  nextruntime,
  status,
  iscontinue,
  createtime,
  queue,
  typeconfig,
  remark,
  retrytime,
  retryinterval
from tsys_winservice
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
            string sql = "delete from tsys_winservice where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsys_Winservice this[int index]
        {
            get
            {
                return new Tsys_Winservice(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsys_Winservice Find(Predicate<Tsys_Winservice> match)
        {
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsys_WinserviceCollection FindAll(Predicate<Tsys_Winservice> match)
        {
            Tsys_WinserviceCollection list = new Tsys_WinserviceCollection();
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsys_Winservice> match)
        {
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsys_Winservice> match)
        {
            BeginTransaction();
            foreach (Tsys_Winservice item in this)
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
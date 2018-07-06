/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tr_Platform.generate.cs 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Company ：深圳市乾海盛世移动支付有限公司
* Copyright (C) Winner研发中心
* CreateTime : 2018-07-02 16:32:52  
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
    /// Data Access Layer Object Of Tr_Platform
    /// </summary>
    public partial class Tr_Platform : DataAccessBase
    {
        #region 默认构造

        public Tr_Platform() : base() { }

        public Tr_Platform(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _platform_id="platform_id";
		public const string _platform_name="platform_name";
		public const string _platform_code="platform_code";
		public const string _status="status";
		public const string _url="url";
		public const string _create_time="create_time";
		public const string _remark="remark";

    
        public const string _TABLENAME="tr_platform";
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
		public string PlatformName
		{
			get { return getProperty<string>(_platform_name); }
			set { setProperty(_platform_name,value); }
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
		public string Url
		{
			get { return getProperty<string>(_url); }
			set { setProperty(_url,value); }
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
			dt.Columns.Add(_platform_name, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_platform_code, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_status, typeof(int)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_url, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_create_time, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_remark, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"delete from tr_platform where " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int platformId)
        {
            string condition = "platform_id=?platform_id";
            AddParameter(_platform_id, platformId);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "platform_id=?platform_id";
            AddParameter(_platform_id, PlatformId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
string sql=@"insert into
tr_platform(
  platform_name,
  platform_code,
  status,
  url,
  remark)
values(
  ?platform_name,
  ?platform_code,
  ?status,
  ?url,
  ?remark)";
			AddParameter(_platform_name,DataRow[_platform_name]);
			AddParameter(_platform_code,DataRow[_platform_code]);
			AddParameter(_status,DataRow[_status]);
			AddParameter(_url,DataRow[_url]);
			AddParameter(_remark,DataRow[_remark]);
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
            sql.AppendLine("update tr_platform set");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=?{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" where platform_id=?platform_id");
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
  platform_name,
  platform_code,
  status,
  url,
  create_time,
  remark
from tr_platform
where " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int platformId)
        {
            string condition = "platform_id=?platform_id";
            AddParameter(_platform_id, platformId);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tr_Platform
    /// </summary>
    public partial class Tr_PlatformCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tr_PlatformCollection() { }

        public Tr_PlatformCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tr_Platform(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tr_Platform().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tr_Platform._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
select
  platform_id,
  platform_name,
  platform_code,
  status,
  url,
  create_time,
  remark
from tr_platform
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
            string sql = "delete from tr_platform where " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tr_Platform this[int index]
        {
            get
            {
                return new Tr_Platform(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tr_Platform Find(Predicate<Tr_Platform> match)
        {
            foreach (Tr_Platform item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tr_PlatformCollection FindAll(Predicate<Tr_Platform> match)
        {
            Tr_PlatformCollection list = new Tr_PlatformCollection();
            foreach (Tr_Platform item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tr_Platform> match)
        {
            foreach (Tr_Platform item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tr_Platform> match)
        {
            BeginTransaction();
            foreach (Tr_Platform item in this)
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
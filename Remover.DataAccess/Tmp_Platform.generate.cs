using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.DataAccess
{
    public partial class Tmp_Platform
    {

    }

    public partial class Tmp_PlatformCollection
    {
        /// <summary>
        /// 根据状态进行查询
        /// </summary>
        /// <returns></returns>
        public bool ListBuyStatus()
        {
            string sql = " STATUS=?STATUS";
            AddParameter("STATUS", (int)PlatformStatus.展示);
            return ListByCondition(sql);
        }

        /// <summary>
        /// 根据名称查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public bool ListByKeyWord(string keyword)
        {
            string sql = "1=1";
            if (!string.IsNullOrEmpty(keyword))
            {
                sql = " PLATFORM_NAME=?keyword";
                AddParameter("keyword", keyword);
            }
            return ListByCondition(sql);
        }

    }

}

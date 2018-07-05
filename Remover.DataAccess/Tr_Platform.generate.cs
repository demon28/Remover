using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.DataAccess
{
    public partial class Tr_Platform
    {

    }

    public partial class Tr_PlatformCollection
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
    }

}

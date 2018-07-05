using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.DataAccess
{
    public partial class Tr_Quotes
    {
        
    }

    public partial class Tr_QuotesCollection
    {
        /// <summary>
        /// 前端获取最新交易数据
        /// </summary>
        /// <returns></returns>
        public bool ListByCurrents()
        {
            string sql = @"SELECT * FROM
	(SELECT	tq.*,tp.platform_name FROM
	    tr_quotes tq join tr_platform tp on tp.platform_id=tq.platform_id
	    ORDER BY
	    tq.create_time DESC
	) tt
    GROUP BY
	tt.market
    ORDER BY
	tt.platform_id DESC,tt.coin_id desc";
            return ListBySql(sql);

        }
    }
}

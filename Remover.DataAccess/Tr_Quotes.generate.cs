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
            string sql = @"select a.*,tr.platform_name from tr_quotes as a right join
(
select max(quotes_id) as max_score from tr_quotes group by market order by quotes_id desc LIMIT 1000
) as b on b.max_score=a.quotes_id
RIGHT JOIN  tr_platform tr on a.platform_id=tr.platform_id 
ORDER BY
	a.platform_id DESC,a.coin_id DESC";
            return ListBySql(sql);

        }
    }
}

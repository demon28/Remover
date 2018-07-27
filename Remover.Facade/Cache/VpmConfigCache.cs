using Remover.DataAccess;
using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Cache;
using Winner.Framework.Utils;

namespace Remover.Facade.Cache
{
    public class VpmConfigCache
    {
        public List<VmpConfigModel> ListConfig()
        {
            var cache = CacheManage.GetInstance();

            var result = cache.Get(CacheConfig.VmpConfigCacheKey, true, () =>
            {
                List<VmpConfigModel> list = new List<VmpConfigModel>();
                Vmp_ConfigCollection daConfigColl = new Vmp_ConfigCollection();
                daConfigColl.ListAll();
                list = MapProvider.Map<VmpConfigModel>(daConfigColl.DataTable);
                return list;
            });
            return result;
        }
    }
}

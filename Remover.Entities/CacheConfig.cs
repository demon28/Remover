using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;

namespace Remover.Entities
{
    public class CacheConfig
    {
        public static string VmpConfigCacheKey
        {
            get
            {
                return ConfigProvider.GetAppSetting("VmpConfigCacheKey", "Vmp_Config_Cache");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class AppConfig
    {
        /// <summary>
        ///  火币访问秘钥
        /// </summary>
        public static string HuoBiApiAccessKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["HuoBiApiAccessKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "37e755e5-603e93ce-2ed6a2f2-d7bb4";
                }
                return ApiSignKey;
            }
        }

        /// <summary>
        /// 火币加密秘钥
        /// </summary>
        public static string HuoBiApiSeceretKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["HuoBiApiSeceretKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "2643ad04-ca71dcf3-df4eed5c-80523";
                }
                return ApiSignKey;
            }
        }




        /// <summary>
        /// OKExAPI秘钥
        /// </summary>
        public static string OkExApiKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["OkExApiKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "daef2b70-357e-44bc-b2ed-dff4fd7edd15";
                }
                return ApiSignKey;
            }
        }


        /// <summary>
        /// OKEx加密秘钥
        /// </summary>
        public static string OkExSecretKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["OkExSecretKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "96886A15CB4FFFD0FCA4C5E0FB4C2D66";
                }
                return ApiSignKey;
            }
        }



        /// <summary>
        /// 币安API秘钥
        /// </summary>
        public static string BiAnApiKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["BiAnApiKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "G0pwhd4kV1LOKqtWAE5hUdvkMhoXZIgtUyx3Wsf3y74IbNdwk7XOaxJE5vcdq8UA";
                }
                return ApiSignKey;
            }
        }


        /// <summary>
        /// 币安加密秘钥
        /// </summary>
        public static string BiAnSecretKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["OkExSecretKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "f5AFEYi1qZZQm6FRil8bpRa29qeqRkxbLaOrlQBBpGdWjdwNvKKuzQ9znmfPeQ7k";
                }
                return ApiSignKey;
            }
        }


        /// <summary>
        /// Gate API秘钥
        /// </summary>
        public static string GateApiKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["GateApiKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "AC0A66AF-2140-4D77-AEB4-D998C389C470";
                }
                return ApiSignKey;
            }
        }


        /// <summary>
        /// Gate加密秘钥
        /// </summary>
        public static string GateSecretKey
        {
            get
            {
                string ApiSignKey = System.Configuration.ConfigurationManager.AppSettings["GateSecretKey"];
                if (string.IsNullOrEmpty(ApiSignKey))
                {
                    return "aa6f6724c0bc992054f8a1d86869fb8c6dbc12edbd3f1cca378beee2cd6e913f";
                }
                return ApiSignKey;
            }
        }





    }
}

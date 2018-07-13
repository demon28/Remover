using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.Encrypt
{
    public class MultipleEncrypt
    {



        public static string SHA256Encrypt(string strIN)
        {
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();
            tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));

            StringBuilder rst = new StringBuilder();
            for (int i = 0; i < tmpByte.Length; i++)
            {
                rst.Append(tmpByte[i].ToString("x2"));
            }
            sha256.Clear();
            return rst.ToString();
            //return GetStringValue(tmpByte);
        }

        public static string SHA512Encrypt(string strIN)
        {
            byte[] tmpByte;
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            tmpByte = sha512.ComputeHash(GetKeyByteArray(strIN));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmpByte.Length; i++)
            {
                sb.Append(tmpByte[i].ToString("x2"));
            }
            sha512.Clear();
            return sb.ToString();
        }

        private static string GetStringValue(byte[] Byte)
        {
            string tmpString = "";
            UTF8Encoding Asc = new UTF8Encoding();
            tmpString = Asc.GetString(Byte);
            return tmpString;
        }

        private static byte[] GetKeyByteArray(string strKey)
        {
            UTF8Encoding Asc = new UTF8Encoding();
            int tmpStrLen = strKey.Length;
            byte[] tmpByte = new byte[tmpStrLen - 1];
            tmpByte = Asc.GetBytes(strKey);
            return tmpByte;
        }
        /// <summary>
        /// 用户火币网加密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        private static string HmacSHA256(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        private static string Base64(string message)
        {
            System.Text.Encoding encode = System.Text.Encoding.UTF8;
            byte[] bytedata = encode.GetBytes(message);
            string strPath = Convert.ToBase64String(bytedata, 0, bytedata.Length);
            return strPath;
        }

        private static string encodingCharset = "UTF-8";
        /**
        *
        * @param aValue  要加密的文字
        * @param aKey  密钥
        * @return
        */
        public static string hmacSign(string aValue, string aKey)
        {
            byte[] k_ipad = new byte[64];
            byte[] k_opad = new byte[64];
            byte[] keyb;
            byte[] value;
            Encoding coding = Encoding.GetEncoding(encodingCharset);
            try
            {
                keyb = coding.GetBytes(aKey);
                // aKey.getBytes(encodingCharset);
                value = coding.GetBytes(aValue);
                // aValue.getBytes(encodingCharset);
            }
            catch (Exception e)
            {
                keyb = null;
                value = null;
                //throw;
            }
            for (int i = keyb.Length; i < 64; i++)
            {
                k_ipad[i] = (byte)54;
                k_opad[i] = (byte)92;
            }
            for (int i = 0; i < keyb.Length; i++)
            {
                k_ipad[i] = (byte)(keyb[i] ^ 0x36);
                k_opad[i] = (byte)(keyb[i] ^ 0x5c);
            }
            byte[] sMd5_1 = MakeMD5(k_ipad.Concat(value).ToArray());
            byte[] dg = MakeMD5(k_opad.Concat(sMd5_1).ToArray());
            return toHex(dg);
        }
        public static string toHex(byte[] input)
        {
            if (input == null)
                return null;
            StringBuilder output = new StringBuilder(input.Length * 2);
            for (int i = 0; i < input.Length; i++)
            {
                int current = input[i] & 0xff;
                if (current < 16)
                    output.Append('0');
                output.Append(current.ToString("x"));
            }
            return output.ToString();
        }
        /**
         * 
         * @param args
         * @param key
         * @return
         */
        public static string getHmac(string[] args, string key)
        {
            if (args == null || args.Length == 0)
            {
                return (null);
            }
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                str.Append(args[i]);
            }
            return (hmacSign(str.ToString(), key));
        }
        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }
        /**
         * SHA加密
         * @param aValue
         * @return
         */
        public static string digest(string aValue)
        {
            aValue = aValue.Trim();
            byte[] value;
            SHA1 sha = null;
            Encoding coding = Encoding.GetEncoding(encodingCharset);
            try
            {
                value = coding.GetBytes(aValue);
                // aValue.getBytes(encodingCharset);
                HashAlgorithm ha = (HashAlgorithm)CryptoConfig.CreateFromName("SHA");
                value = ha.ComputeHash(value);
            }
            catch (Exception e)
            {
                //value = coding.GetBytes(aValue);
                throw;
            }
            return toHex(value);
        }

        
    }
}

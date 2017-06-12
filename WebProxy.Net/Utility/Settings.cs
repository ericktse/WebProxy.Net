﻿using System.Collections.Specialized;
using System.Configuration;

namespace WebProxy.Net.Utility
{
    public class Settings
    {
        /// <summary>
        /// 验签密钥配置
        /// </summary>
        public static NameValueCollection WebDesKeys
        {
            get
            {
                return (NameValueCollection)ConfigurationManager.GetSection("webDesKey");
            }
        }

        /// <summary>
        /// 获取验签密钥
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDesKey(string key)
        {
            string originalKey = WebDesKeys[key.ToLower()];
            string md5 = EncryptHelper.GetMd5Hash(originalKey);

            return md5.Substring(0, 8);
        }
    }
}
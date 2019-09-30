using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QzoneSpider
{
    class SecretToken
    {
        private string cookie;
        private string[] keyvalue;

        public SecretToken(string cookie)
        {
            this.cookie = cookie;
            Initialize();
        }

        private void Initialize()
        {
            keyvalue = cookie.Split(new string[]{"; "}, StringSplitOptions.RemoveEmptyEntries);
        }

        public int GetAntiCsrfToken()
        {
            string i = GetKey("p_skey");
            if (i == null || i == "")
            {
                i = GetKey("wxvip_access_token");
                if (i == null || i == "")
                {
                    return 0;
                }
            }
            int t = 5381;
            for (int n = 0, o = i.Length; n < o; ++n)
            {
                t += (t << 5) + i[n];
            }
            return t & 2147483647;
        }

        private string GetKey(string key)
        {
            string r = null;
            foreach (string value in keyvalue) {
                if (value.StartsWith(key))
                {
                    r = value.Substring(value.IndexOf('=') + 1);
                }
            }
            return r;
        }
    }
}

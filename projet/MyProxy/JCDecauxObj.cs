using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyProxy
{
    class JCDecauxObj
    {
        protected ProxyCache<JCDecauxObj> cache;
        protected static string URI = "";
        protected HttpClient req = new HttpClient();
        protected string jsonObj = "";

        public JCDecauxObj()
        {
            //jsonObj = req.GetAsync(URI);
        }

        public JCDecauxObj(string uri)
        {
            Task < HttpResponseMessage > resp = req.GetAsync(uri);
            jsonObj = resp.Result.Content.ReadAsStringAsync().Result.ToString();
        }

        public string getjsonObj() { return jsonObj; }

    }
}

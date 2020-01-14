using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CurrencyExchange.Utils
{
    public static class IOHelper
    {
        public static dynamic fnOpenFile(string pStrJsonTemplatefilepath)
        {
            JArray vObjJsonTemplate = null;
            FileStream fs = new FileStream(pStrJsonTemplatefilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            var _JsonTemplatefile = sr.ReadToEnd();
            sr.Close();
            vObjJsonTemplate = JsonConvert.DeserializeObject<JArray>(_JsonTemplatefile);
            return vObjJsonTemplate;
        }
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class func
{
    public static string NewsType = "{1:'新闻',2:'类型'}"; 
    public static string json_value(string key, string jsonStr)
    {
        JObject json = (JObject)JsonConvert.DeserializeObject(jsonStr);
        string jsonvalue = "";
        if (json[key] != null)
        {
            jsonvalue = json[key].ToString();
        }
        return jsonvalue;
    }
}


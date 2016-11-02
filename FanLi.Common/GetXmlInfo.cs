using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
 

namespace FanLi.Common
{
   public class GetXmlInfo
    {
        /// <summary>
        /// 获取/Content/admin.xml
        /// </summary>
        /// <returns></returns>
        public static List<commonModel> GetcommonList(string levelName)
        {
            var xdoc = XElement.Load(System.Web.HttpContext.Current.Server.MapPath("/Content/admin.xml"));

            var list = from items in xdoc.Element(levelName).Descendants("item") select new commonModel { id = items.Element("id").Value, value = items.Element("value").Value };
          
            List<commonModel> listmodel = new List<commonModel>();
            foreach (var item in list)
            {
                commonModel model = new commonModel();
                model.id = item.id;
                model.value = item.value;
                listmodel.Add(model);
            }
            return listmodel;
        }

    }
    public class commonModel
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}

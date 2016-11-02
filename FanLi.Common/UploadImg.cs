using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FanLi.Common
{
    public class UploadImg
    {
        public static string Upload(HttpPostedFileBase fileimg, out string outPath)
        {
            outPath = "";
            try
            {

                //获取上传文件的后缀 
                String fileExtension = Utils.GetFileExt(fileimg.FileName); ;
                //判断文件类型是否符合要求 
                if (!IsImage(fileExtension)) return "只能够上传后缀为.gif,.jpg,.bmp,.png的文件";

                //上传文件是否大于10M
                if (fileimg.ContentLength > (10 * 1024 * 1024))
                {
                    return "上传文件过大";
                }
                //检查上传的物理路径是否存在，不存在则创建
                string savePath = HttpContext.Current.Request.PhysicalApplicationPath + "/uploads/";
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string newFileName = GetNewName(fileExtension); //生成新的文件名
                string allPath = savePath + newFileName;
                //保存文件
                fileimg.SaveAs(allPath);
                outPath = ConfigurationManager.AppSettings["domain"].ToString() + "/upload/" + newFileName;
                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static string GetNewName(string fileExt)
        {
            return Guid.NewGuid() + "." + fileExt;
        }
        private static bool IsImage(string fileExt)
        {
            string _fileType = "jpg;jpeg;gif;bmp;png";
            //检查合法文件
            string[] allowExt = _fileType.Split(';');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

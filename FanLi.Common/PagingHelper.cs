using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.Common
{
   public static class PagingHelper
    {
        /// <summary>
        /// 返回分页页码
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="linkUrl">链接地址，__id__代表页码</param>
        /// <param name="centSize">中间页码数量</param>
        /// <returns></returns>
        public static string OutPageList(int pageSize, int pageIndex, int totalCount, string linkUrl, int centSize)
        {
            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return "";
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return "";
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return "";
            }
            StringBuilder pageStr = new StringBuilder();
            string pageId = "__id__";
            string firstBtn = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, (pageIndex - 1).ToString()) + "\">«上一页</a>";
            string lastBtn = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, (pageIndex + 1).ToString()) + "\">下一页»</a>";
            string firstStr = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, "1") + "\">1</a>";
            string lastStr = "<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a>";

            if (pageIndex <= 1)
            {
                firstBtn = "<span class=\"disabled\">«上一页</span>";
            }
            if (pageIndex >= pageCount)
            {
                lastBtn = "<span class=\"disabled\">下一页»</span>";
            }
            if (pageIndex == 1)
            {
                firstStr = "<span class=\"current\">1</span>";
            }
            if (pageIndex == pageCount)
            {
                lastStr = "<span class=\"current\">" + pageCount.ToString() + "</span>";
            }
            int firstNum = pageIndex - (centSize / 2); //中间开始的页码
            if (pageIndex < centSize)
                firstNum = 2;
            int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码
            if (lastNum >= pageCount)
                lastNum = pageCount - 1;
            pageStr.Append("<span>共" + totalCount + "记录</span>");
            pageStr.Append(firstBtn + firstStr);
            if (pageIndex >= centSize)
            {
                pageStr.Append("<span>...</span>\n");
            }
            for (int i = firstNum; i <= lastNum; i++)
            {
                if (i == pageIndex)
                {
                    pageStr.Append("<span class=\"current\">" + i + "</span>");
                }
                else
                {
                    pageStr.Append("<a href=\"" + Utils.ReplaceStr(linkUrl, pageId, i.ToString()) + "\">" + i + "</a>");
                }
            }
            if (pageCount - pageIndex > centSize - ((centSize / 2)))
            {
                pageStr.Append("<span>...</span>");
            }
            pageStr.Append(lastStr + lastBtn);
            return pageStr.ToString();
        }

        public static string pageInation(int total, int pageSize, int page, int allpage, string strW)
        {
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            //string pagestr = "";
            StringBuilder pagestr = new StringBuilder();

            string Inid = string.Empty;
            if (page < 1)
            {
                page = 1;
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 3) > allpage ? allpage - 5 : page - 2;
            //中间页终止序号
            endcount = page < 3 ? 6 : page + 3;
            //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (startcount < 1)
            {
                startcount = 1;
            }
            //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            if (allpage < endcount)
            {
                endcount = allpage;
            }
            pagestr.Append("<a href='?page=1" + strW + "'>首&nbsp;页</a>");
            string pageReg = "<a href='?page=#" + strW + "' $>%</a>";

            pagestr.Append(pageReg.Replace("#", "" + (page <= 1 ? 1 : pre).ToString()).Replace("$", "").Replace("%", "上一页"));

            for (int i = startcount; i <= endcount; i++)
            {
                if (i == page)
                {
                    pagestr.Append(pageReg.Replace("#", "" + i.ToString())
                        .Replace("$", " class='pct'")
                        .Replace("%", i.ToString()));
                }
                else
                {
                    pagestr.Append(pageReg.Replace("#", "" + i.ToString()).Replace("$", "").Replace("%", i.ToString()));
                }
            }

            pagestr.Append(
                pageReg.Replace("#", "" + (next >= allpage ? allpage : next).ToString())
                    .Replace("$", "")
                    .Replace("%", "下一页"));
            pagestr.Append("<a href='?page=" + allpage + strW + "'>尾&nbsp;页</a>");


            //pagestr.Append("&nbsp;跳转<input type='text' style='width:40px;' id='txtPage' onkeyup=\"this.value=this.value.replace(/\\D/g,'')\" onblur=\"if(this.value>" + allpage + "){alert('超出页码范围！');this.value='';this.focus();}\" />");
            //pagestr.Append("<input type='button' style='width:40px;' id='btnJumpPage' value='跳转' onclick='jumpPage()' />");
            //pagestr.Append("&nbsp;&nbsp;共<span class=''>" + allpage + "</span>页" + total + "条数据");
            //pagestr.Append("<script>function jumpPage(){var p=document.getElementById(\"txtPage\").value; if(p!=''&&p>0)location.href='?page='+p+'" + strW + "'}</script>");
            return pagestr.ToString();
        }

        /// <summary>
        /// 用户中心分页
        /// </summary>
        /// <param name="total">总条数</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="page">当前页数</param>
        /// <param name="pageUrl">页面地址</param>
        /// <param name="strW">条件</param> 
        /// <param name="overClass">鼠标经过样式</param>
        /// <returns></returns>
        public static string pageInation(int total, int pageSize, int page, string pageUrl, string strW, string overClass)
        {
            //不够一页不显示
            if (total < pageSize)
            {
                return "";
            }
            //算出总页数
            int allpage = total % pageSize == 0 ? total / pageSize : total / pageSize + 1;

            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            //string pagestr = "";
            StringBuilder pagestr = new StringBuilder();

            string Inid = string.Empty;
            if (page < 1)
            {
                page = 1;
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 3) > allpage ? allpage - 5 : page - 2;
            //中间页终止序号
            endcount = page < 3 ? 6 : page + 3;
            //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (startcount < 1)
            {
                startcount = 1;
            }
            //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            if (allpage < endcount)
            {
                endcount = allpage;
            }
            pagestr.Append("<a href='" + pageUrl + "?page=1" + strW + "'>首&nbsp;页</a>");
            string pageReg = "<a href='" + pageUrl + "?page=#" + strW + "' $>%</a>";

            if (page != 1)
            {
                pagestr.Append(pageReg.Replace("#", "" + (page <= 1 ? 1 : pre).ToString())
                    .Replace("$", "")
                    .Replace("%", "上一页"));
            }
            for (int i = startcount; i <= endcount; i++)
            {
                if (i == page)
                {
                    pagestr.Append(pageReg.Replace("#", "" + i.ToString())
                        .Replace("$", " class='" + overClass + "'")
                        .Replace("%", i.ToString()));
                }
                else
                {
                    pagestr.Append(pageReg.Replace("#", "" + i.ToString()).Replace("$", "").Replace("%", i.ToString()));
                }
            }
            if (page != allpage)
            {
                pagestr.Append(
                    pageReg.Replace("#", "" + (next >= allpage ? allpage : next).ToString())
                        .Replace("$", "")
                        .Replace("%", "下一页"));
            }
            pagestr.Append("<a href='" + pageUrl + "?page=" + allpage + strW + "'>尾&nbsp;页</a>");
            pagestr.Append("<span class=''>共 " + allpage + " 页</span>");

            return pagestr.ToString();
        }

    }
}

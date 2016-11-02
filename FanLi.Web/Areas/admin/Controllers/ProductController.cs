using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanLi.Models;
using FanLi.BLL;
using FanLi.IBLL;
using FanLi.Web.Areas.admin.Models;
using Webdiyer.WebControls.Mvc;

namespace FanLi.Web.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductsService productBll = new ProductsBLL();
        private IProductTypeService producttypeBll = new ProductTypeBLL();
        private IMallsService mallsBll = new MallsBLL();
        // GET: admin/Product 
        public ActionResult list(int page = 1, int pageSize = 20)
        {
            int totalCount = 0;
            PagedList<Products> InfoPager = productBll.FindPageList(page, pageSize, out totalCount, "Id", false).AsQueryable().ToPagedList(page, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = page;
            //数据组装到viewModel
            ProductListViewModel index = new ProductListViewModel ();

            index.Infos = InfoPager;
            return View(index);
        }
        public ActionResult add()
        {
            ProductsAddViewModel addviewModel = new ProductsAddViewModel();
            IEnumerable<SelectListItem> mallslist = mallsBll.FindList(pt => true, true, "Id").ToList().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            });
            addviewModel.ListMalls = mallslist;

            List<ProductType> onelist = producttypeBll.FindList(p => p.tpLevel == 1, true, "Id").ToList();
            ViewData["ptypone"] = onelist;

            return View(addviewModel);
        }
        [HttpPost]
        public JsonResult GetproductType()
        {
            int level = Convert.ToInt32(Request.Form["level"]);
            int pid = Convert.ToInt32(Request.Form["pid"]);
            List<ProductType> typetlist = producttypeBll.FindList(p => p.tpLevel == level && p.ParentId==pid, true, "Id").ToList();
            return Json(typetlist);
        }
        
        
        public ActionResult addType()
        {
            List<ProductType> onelist = producttypeBll.FindList(p => p.tpLevel == 1, true, "Id").ToList(); 
            ViewData["ptypone"] = onelist; 

            return View();
        }
        public ActionResult listType(int pid = 0)
        {
             
            ProductTypeListViewModel _model = new Models.ProductTypeListViewModel();
            var _rows = producttypeBll.FindList(p => p.ParentId == pid, true, "Id").ToList();
            if (pid == 0)
                _model.parentName = "无";
            else
            _model.parentName = producttypeBll.Find(m => m.Id == pid).tpName;

            _model.productTypeList = _rows;
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(Products model)
        {
            if (ModelState.IsValid)
            {
                model.CreateTime = DateTime.Now;
                model.IsCheck = 1;
                model.IsShow = true;
                model = productBll.Add(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("list");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addType(ProductType model)
        {
            if (ModelState.IsValid)
            {
                model = producttypeBll.Add(model);
                if (model.Id > 0)
                {
                    Response.Write("添加成功");
                }
                else { ModelState.AddModelError("", "添加失败！"); }
            }
            return View();
        }
    }
}